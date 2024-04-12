using System;

namespace Dhhr.KppParser.Service
{
    public class Args
    {
        public string EpisodePath { get; set; }
        public string TjenestePath { get; set; }
        public string OutputPath { get; set; }

        public string ProgramVersion { get; set; }
        public string Leverandor { get; set; }
        public string NavnEpj { get; set; }
        public string VersjonEpj { get; set; }

        public DateTime FraDato { get; set; }
        public DateTime TilDato { get; set; }

        public string OrganizationName { get; set; }
        public string OrganizationHerId { get; set; }
        public string OrganizationName2 { get; set; }
        public string OrganizationHerId2 { get; set; }

        public string FhiHerId { get; set; }

        public override string ToString()
        {
            return $"{nameof(EpisodePath)}: {F(EpisodePath)}," +
                $"\n{nameof(TjenestePath)}: {F(TjenestePath)}," +
                $"\n{nameof(OutputPath)}: {F(OutputPath)}," +
                $"\n{nameof(ProgramVersion)}: {F(ProgramVersion)}," +
                $"\n{nameof(Leverandor)}: {F(Leverandor)}," +
                $"\n{nameof(NavnEpj)}: {F(NavnEpj)}," +
                $"\n{nameof(VersjonEpj)}: {F(VersjonEpj)}," +
                $"\n{nameof(FraDato)}: {F(FraDato)}," +
                $"\n{nameof(TilDato)}: {F(TilDato)}," +
                $"\n{nameof(OrganizationName)}: {F(OrganizationName)}," +
                $"\n{nameof(OrganizationHerId)}: {F(OrganizationHerId)}," +
                $"\n{nameof(OrganizationName2)}: {F(OrganizationName2)}," +
                $"\n{nameof(OrganizationHerId2)}: {F(OrganizationHerId2)}," +
                $"\n{nameof(FhiHerId)}: {F(FhiHerId)}";
        }

        private static string F(string s)
        {
            return string.IsNullOrWhiteSpace(s)
                ? "Ikke angitt"
                : s;
        }

        private static string F(DateTime dt)
        {
            return dt == default(DateTime)
                ? "Ikke angitt / Feil format"
                : dt.ToString("yyyy-MM-dd");
        }
    }
}
