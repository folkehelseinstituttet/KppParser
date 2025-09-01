using System.Configuration;

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

        public void Validate()
        {
            BatchFiles?.Validate();
        }
    }

    public class BatchFileSettings
    {
        public bool EnableCreation { get; set; }
        public int MaxFileSizeInGigabytes { get; set; }

        internal void Validate()
        {
            if (EnableCreation && MaxFileSizeInGigabytes == 0)
            {
                throw new ConfigurationErrorsException($"{nameof(Settings.BatchFiles)}: When {nameof(EnableCreation)} is true, {nameof(MaxFileSizeInGigabytes)} needs to be larger than 0.");
            }
        }
    }
}
