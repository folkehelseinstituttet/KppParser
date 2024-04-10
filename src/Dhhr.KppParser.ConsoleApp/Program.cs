using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using Dhhr.KppParser.Service;
using Mono.Options;

namespace Dhhr.KppParser.ConsoleApp
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            var verbose = false;
            var showHelp = args.Length == 0;
            var dryRun = false;
            var printVersion = false;

            var kppArgs = new Args
            {
                ProgramVersion = Version()
            };

            var p = new OptionSet
            {
                {"Program-argumenter"},
                {"h|help", "Vis hjelp", x => showHelp = true },
                {"v|verbose", "Skriv status underveis", x => verbose = true },
                {"d|dry-run", "Test konfigurasjon uten å kjøre programmet.", x => dryRun = true },
                {"version", "Skriv programmets version", x => printVersion = true },
                {"Input"},
                {"episoder=", "Filsti til csv-fil med episoder", x => kppArgs.EpisodePath = x },
                {"tjenester=", "Filsti til csv-fil med tjenester", x => kppArgs.TjenestePath = x },
                {"fradato=", "Dato for periodens start. Format: yyyy-MM-dd", x => kppArgs.FraDato = ParseDate(x)},
                {"tildato=", "Dato for periodens slutt. Format: yyyy-MM-dd", x => kppArgs.TilDato = ParseDate(x)},
                {"org-herid=", "Avsenders HerId (fra Adresseregisteret)", x => kppArgs.OrganizationHerId = x },
                {"org-navn=", "Avsenders navn", x => kppArgs.OrganizationName = x },
                {"org-herid2=", "Avsenders HerId (Nivå 2 i MsgHead)", x => kppArgs.OrganizationHerId2 = x },
                {"org-navn2=", "Avsenders navn (Nivå 2 i MsgHead)", x => kppArgs.OrganizationName2 = x },
                {"leverandor=", "Navn på leverandør av EPJ", x => kppArgs.Leverandor = x},
                {"epj-navn=", "Navn på EPJ", x => kppArgs.NavnEpj = x },
                {"epj-versjon=", "Versjon av EPJ", x => kppArgs.VersjonEpj = x },
                {"fhi-herid=", "FHIs HerId.", x => kppArgs.FhiHerId = x },
                {"Output" },
                {"o|output=", "Filsti hvor resultatet lagres", x => kppArgs.OutputPath = x}
            };

            Console.WriteLine();

            var list = p.Parse(args);
            if (list.Count > 0)
            {
                Console.WriteLine($"Ukjente variable: {string.Join(", ", list)}\n");
                p.WriteOptionDescriptions(Console.Out);
                return 1;
            }

            if (showHelp)
            {
                p.WriteOptionDescriptions(Console.Out);
                return 0;
            }

            if (printVersion)
            {
                Console.WriteLine(Version());
                return 0;
            }

            if (dryRun)
            {
                Console.WriteLine("# Tolket input:");
                Console.WriteLine(kppArgs.ToString());

                Console.WriteLine();
                var message = !KppService.IsValid(kppArgs, out var em)
                    ? $"# Fant følgende feil i input:\n{em}"
                    : "# Input er gyldig";
                Console.WriteLine(message);
                return 0;
            }

            if (!KppService.IsValid(kppArgs, out var errorMessage))
            {
                Console.WriteLine($"Feil input:\n{errorMessage}");
                return 1;
            }

            try
            {
                KppService.Run(kppArgs, (i, s) => Log(s, verbose));
            }
            catch (Exception ex)
            {
                var message = $"Noe gikk galt under opprettelse av meldingen.\n\nFeilmelding: {ex.Message}\n\n{ex.GetType()}\n\nVersjon: {kppArgs.ProgramVersion}";
                Console.WriteLine(message);
                return 1;
            }

            return 0;
        }

        private static DateTime ParseDate(string x)
        {
            return DateTime.TryParseExact(x, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tmp)
                ? tmp
                : DateTime.MinValue;
        }

        private static string Version()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
            return $"c{version}"; // c indicates "ConsoleApp"
        }

        private static void Log(string status, bool verbose)
        {
            if (verbose)
            {
                Console.WriteLine(status);
            }
        }
    }
}
