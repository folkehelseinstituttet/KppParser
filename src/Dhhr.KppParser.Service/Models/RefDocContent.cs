using System.Xml.Serialization;

namespace Dhhr.KppParser.Service.Models
{
    public partial class RefDocContent
    {
        [XmlElement(Namespace = "http://www.npr.no/xmlstds/57_0_1_kpp", ElementName = "Melding")]
        public Melding Melding { get; set; }
    }
}
