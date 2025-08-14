namespace Dhhr.KppParser.Gui
{
    public class Settings
    {
        public string Leverandor { get; set; }
        public string NavnEpj { get; set; }
        public string VersjonEpj { get; set; }
        public string FhiQa { get; set; }
        public string FhiProd { get; set; }

        public BatchFileSettings BatchFiles { get; set; }
    }

    public class BatchFileSettings
    {
        public bool EnableCreation { get; set; }
        public long MaxFileSizeInBytes { get; set; }
    }
}
