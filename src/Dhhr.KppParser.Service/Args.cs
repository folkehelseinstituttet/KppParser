using System;

namespace Dhhr.KppParser.Service
{
    public class Args
    {
        private const long GigabyteInBytes = 1L * 1024 * 1024 * 1024;

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

        public BatchFileArgs BatchFiles { get; set; } = new();

        public virtual long MaxBatchFileSizeInBytes => GigabyteInBytes * BatchFiles.MaxFileSizeInGigabytes;

        public override string ToString()
        {
            return $"{nameof(EpisodePath)}: {F(EpisodePath)}," +
                $"\r\n{nameof(TjenestePath)}: {F(TjenestePath)}," +
                $"\r\n{nameof(OutputPath)}: {F(OutputPath)}," +
                $"\r\n{nameof(ProgramVersion)}: {F(ProgramVersion)}," +
                $"\r\n{nameof(Leverandor)}: {F(Leverandor)}," +
                $"\r\n{nameof(NavnEpj)}: {F(NavnEpj)}," +
                $"\r\n{nameof(VersjonEpj)}: {F(VersjonEpj)}," +
                $"\r\n{nameof(FraDato)}: {F(FraDato)}," +
                $"\r\n{nameof(TilDato)}: {F(TilDato)}," +
                $"\r\n{nameof(OrganizationName)}: {F(OrganizationName)}," +
                $"\r\n{nameof(OrganizationHerId)}: {F(OrganizationHerId)}," +
                $"\r\n{nameof(OrganizationName2)}: {F(OrganizationName2)}," +
                $"\r\n{nameof(OrganizationHerId2)}: {F(OrganizationHerId2)}," +
                $"\r\n{nameof(FhiHerId)}: {F(FhiHerId)}," +
                $"\r\n{nameof(BatchFiles)}: {{" +
                $"\r\n    {nameof(BatchFiles.EnableCreation)}: {BatchFiles.EnableCreation}" +
                $"\r\n    {nameof(BatchFiles.MaxFileSizeInGigabytes)}: {BatchFiles.MaxFileSizeInGigabytes}" +
                $"\r\n}}";
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

    public class BatchFileArgs
    {
        public bool EnableCreation { get; set; }
        public int MaxFileSizeInGigabytes { get; set; }
    }
}
