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
        public static readonly Encoding Encoding = Encoding.UTF8;

        public static void SerializeToFile<T>(T obj, string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var fileStream = File.Create(path))
            using (var writer = new XmlTextWriter(fileStream, Encoding))
            {
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, obj);
            }
        }

        public static XmlDocument SerializeToXmlDocument<T>(T obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            var stringWriter = new KppStringWriter();

            using var writer = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true });
            serializer.Serialize(writer, obj);

            var document = new XmlDocument { PreserveWhitespace = true };
            document.LoadXml(stringWriter.ToString());

            return document;
        }

        public static T DeserializeFromFile<T>(string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(path))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static void SaveToFile(XmlDocument doc, string path)
        {
            doc.Save(path);
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
