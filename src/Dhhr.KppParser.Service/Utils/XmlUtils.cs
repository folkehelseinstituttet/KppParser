using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Dhhr.KppParser.Service.Utils
{
    public static class XmlUtils
    {
        public static void SerializeToFile<T>(T obj, string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var fileStream = File.Create(path))
            using (var writer = new XmlTextWriter(fileStream, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, obj);
            }
        }

        public static T DeserializeFromFile<T>(string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(path))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static void ValidateXmlFile(string path, XmlSchemaSet schemaSet)
        {
            var settings = new XmlReaderSettings
            {
                Schemas = schemaSet,
                ValidationType = ValidationType.Schema,
                DtdProcessing = DtdProcessing.Ignore,
                ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings
            };

            settings.ValidationEventHandler += (sender, args) => throw new XmlException(args.Message, args.Exception);

            using (var reader = XmlReader.Create(path, settings))
            {
                XDocument.Load(reader);
            }
        }
    }
}
