using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dhhr.KppParser.Service.Utils;

namespace Dhhr.KppParser.Service
{
    public static class KppService
    {
        public static bool IsValid(Args args, out string errorMessage)
        {
            var errors = new List<string>();
            try
            {
                var validateEpisode = ValidateEpisode(args.EpisodePath);
                if (validateEpisode != null)
                {
                    errors.Add(validateEpisode);
                }

                var validateTjeneste = ValidateTjeneste(args.TjenestePath);
                if (validateTjeneste != null)
                {
                    errors.Add(validateTjeneste);
                }

                if (args.FraDato == default(DateTime))
                {
                    errors.Add("FraDato er ikke satt");
                }

                if (args.TilDato == default(DateTime))
                {
                    errors.Add("TilDato er ikke satt");
                }

                if (args.FraDato.Date > args.TilDato.Date)
                {
                    errors.Add(Constants.DateMismatch);
                }

                if (!int.TryParse(args.OrganizationHerId, out _))
                {
                    errors.Add(Constants.InvalidSenderHerId);
                }

                if (string.IsNullOrWhiteSpace(args.OrganizationName))
                {
                    errors.Add(Constants.InvalidOrgName);
                }

                if (!int.TryParse(args.OrganizationHerId2, out _))
                {
                    errors.Add(Constants.InvalidSenderHerId2);
                }

                if (string.IsNullOrWhiteSpace(args.OrganizationName2))
                {
                    errors.Add(Constants.InvalidOrgName2);
                }

                if (string.IsNullOrWhiteSpace(args.Leverandor))
                {
                    errors.Add("Leverandør mangler verdi");
                }

                if (string.IsNullOrWhiteSpace(args.NavnEpj))
                {
                    errors.Add("NavnEpj mangler verdi");
                }

                if (string.IsNullOrWhiteSpace(args.VersjonEpj))
                {
                    errors.Add("VersjonEpj mangler verdi");
                }

                if (!int.TryParse(args.FhiHerId, out _))
                {
                    errors.Add("FhiHerId er ikke gyldig");
                }

                if (args.BatchFiles is { EnableCreation: true, MaxFileSizeInGigabytes: 0})
                {
                    errors.Add("Når opprettelse av delmeldinger er aktivert må maks. filstørrelse være større enn 0");
                }
            }
            catch (Exception ex)
            {
                errors.Add($"Ukjent feil ({ex.GetType()})");
            }

            errorMessage = string.Join("\n", errors);

            return !errors.Any();
        }

        private static string ValidateEpisode(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return Constants.Episode.EmptyFileName;
            }

            if (!File.Exists(filePath))
            {
                return Constants.Episode.DoesNotExist;
            }

            var lines = File.ReadLines(filePath);
            var first = lines.First();

            if (!string.Equals(first, "institusjonsID;episodeID;drg;total", StringComparison.InvariantCultureIgnoreCase))
            {
                return Constants.Episode.InvalidHeader;
            }

            return null;
        }

        private static string ValidateTjeneste(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return Constants.Tjeneste.EmptyFileName;
            }

            if (!File.Exists(filePath))
            {
                return Constants.Tjeneste.DoesNotExist;
            }

            var lines = File.ReadLines(filePath);
            var first = lines.First();

            if (!string.Equals(first, "episodeID;kostnadskode;kostnad", StringComparison.InvariantCultureIgnoreCase))
            {
                return Constants.Tjeneste.InvalidHeader;
            }

            return null;
        }

        public static void Run(Args args, Action<int, string> reportStatus, Action<string> userNotificator)
        {
            reportStatus?.Invoke(10, "Leser data...");
            var institutions = MessageUtils.ParseFiles(args.EpisodePath, args.TjenestePath);
            var message = MessageUtils.CreateMessage(args, institutions);

            var wrapped = MessageUtils.WrapInMsgHead(message, args);

            reportStatus?.Invoke(30, "Genererer melding...");
            var xmlDocument = XmlUtils.SerializeToXmlDocument(wrapped);

            if (MessageUtils.ShouldCreateBatchFiles(args, xmlDocument, out var fileCount))
            {
                BatchMessageUtils.TryCreateFiles(args, reportStatus, userNotificator, message, fileCount);
                return;
            }

            if (!MessageUtils.HasSingleInstitution(message))
            {
                userNotificator?.Invoke("Episode-filen og den genererte meldingen inneholder flere institusjon-IDer: " +
                                        string.Join(", ", message.Institusjon.Select(i => i.institusjonID)) +
                                        Environment.NewLine + Environment.NewLine +
                                        "Vi ber om at det kun rapporteres et unikt organisasjonsnummer som institusjonID i NPR_KPP-meldingen.");
            }

            reportStatus?.Invoke(50, "Lagrer melding...");
            Directory.CreateDirectory(Path.GetDirectoryName(args.OutputPath));
            XmlUtils.SaveToFile(xmlDocument, args.OutputPath);

            reportStatus?.Invoke(75, "Kontrollerer melding...");
            var schemas = SchemaLoader.LoadDirectory("Resources");
            XmlUtils.ValidateXmlFile(args.OutputPath, schemas);

            reportStatus?.Invoke(100, "Ferdig");
        }
    }
}
