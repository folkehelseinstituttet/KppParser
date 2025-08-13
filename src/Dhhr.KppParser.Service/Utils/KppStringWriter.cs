using System.IO;
using System.Text;

namespace Dhhr.KppParser.Service.Utils;

public sealed class KppStringWriter : StringWriter
{
    public override Encoding Encoding => XmlUtils.Encoding;
}
