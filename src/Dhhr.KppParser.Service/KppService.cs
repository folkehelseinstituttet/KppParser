using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dhhr.KppParser.Service.Models;
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

                if (!int.TryParse(args.HDirHerId, out _))
                {
                    errors.Add("HDirHerId er ikke gyldig");
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

        public static void Run(Args args, Action<int, string> reportStatus)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(args.OutputPath));

            reportStatus?.Invoke(10, "Leser data...");
            var melding = CreateMelding(args);

            var wrapped = WrapInMsgHead(melding, args);

            reportStatus?.Invoke(50, "Lagrer melding...");
            XmlUtils.SerializeToFile(wrapped, args.OutputPath);

            reportStatus?.Invoke(75, "Kontrollerer melding...");
            var schemas = SchemaLoader.LoadDirectory("Resources");
            XmlUtils.ValidateXmlFile(args.OutputPath, schemas);

            reportStatus?.Invoke(100, "Ferdig");
        }

        private static Melding CreateMelding(Args args)
        {
            return new Melding
            {
                lopenr = DateTime.UtcNow.ToString("yyyyMMddHHmmssffff"),
                lokalident = Guid.NewGuid().ToString(),
                uttakDato = DateTime.Today,
                versjonUt = args.ProgramVersion,
                meldingstype = meldingstype.B,
                fraDatoPeriode = args.FraDato,
                tilDatoPeriode = args.TilDato,
                leverandor = args.Leverandor,
                navnEPJ = args.NavnEpj,
                versjonEPJ = args.VersjonEpj,
                Institusjon = ParseFiles(args.EpisodePath, args.TjenestePath)
            };
        }

        private static List<Institusjon> ParseFiles(string episodePath, string tjenestePath)
        {
            var tjenester = File.ReadLines(tjenestePath)
                .Skip(1) // skip header
                .Select(line => line.Split(';'))
                .ToLookup(
                    parts => parts[0], // episodeID
                    parts => TjenesteKPP.Create(parts[1], parts[2]));

            var episoder = File.ReadLines(episodePath)
                .Skip(1) // skip header
                .Select(line => line.Split(';'))
                .GroupBy(
                    parts => parts[0], // institusjonID
                    parts => EpisodeKPP.Create(parts[1], parts[2], parts[3], tjenester[parts[1]]));

            return episoder
                .Select(kpps => Institusjon.Create(kpps.Key, kpps.ToList()))
                .ToList();
        }

        private static MsgHead WrapInMsgHead(Melding melding, Args args)
        {
            return new MsgHead
            {
                Items = new object[]
                {
                    new Document
                    {
                        RefDoc = new RefDoc
                        {
                            MsgType = new CS { V = "XML", DN = "XML-instans" },
                            Item = new RefDocContent { Melding = melding }
                        }
                    }
                },
                MsgInfo = new MsgInfo
                {
                    Type = new CS { V = "NPR_KPP", DN = "KPP melding" },
                    GenDate = DateTime.Now,
                    MsgId = Guid.NewGuid().ToString(),
                    Sender = new Sender
                    {
                        Organisation = new Organisation
                        {
                            OrganisationName = args.OrganizationName,
                            Ident = new []
                            {
                                new Ident
                                {
                                    Id = args.OrganizationHerId,
                                    TypeId = new CV { V = "HER", DN = "HER-Id", S = "9051" }
                                }
                            }
                        }
                    },
                    Receiver = new Receiver
                    {
                        Organisation = new Organisation
                        {
                            OrganisationName = "Helsedirektoratet",
                            Ident = new[]
                            {
                                new Ident
                                {
                                    Id = args.HDirHerId,
                                    TypeId = new CV { V = "HER", DN = "HER-Id", S = "9051" }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
