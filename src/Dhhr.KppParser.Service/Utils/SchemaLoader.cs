using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;

namespace Dhhr.KppParser.Service.Utils
{
    public static class SchemaLoader
    {
        private static readonly XmlReaderSettings XmlReaderSettings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Ignore };

        public static XmlSchemaSet LoadDirectory(string rootPath)
        {
            var paths = Directory.EnumerateFiles(rootPath, "*.xsd", SearchOption.AllDirectories);
            return Load(paths);
        }

        public static XmlSchemaSet Load(IEnumerable<string> paths)
        {
            var schemaSet = new XmlSchemaSet
            {
                XmlResolver = null,
                CompilationSettings = { EnableUpaCheck = false }
            };

            foreach (var path in paths)
            {
                schemaSet.Add(GetSchema(path));
            }

            schemaSet.Compile();
            return schemaSet;
        }

        private static XmlSchema GetSchema(string filename)
        {
            string path;
            if (Path.IsPathRooted(filename))
            {
                path = filename;
            }
            else
            {
                // Relative paths doesn't work, so we need to set it to an absolute path
                var assemblyLocation = System.AppContext.BaseDirectory;
                path = Path.Combine(assemblyLocation, filename);
            }

            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = XmlReader.Create(fileStream, XmlReaderSettings, path))
            {
                return XmlSchema.Read(reader, null);
            }
        }
    }
}
