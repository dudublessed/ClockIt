using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace ClockIt.src.Shared.Utils
{
    public static class FileHelper
    {
        public static string GetJsonFileContent(string jsonFile)
        {
            using var stream =
                Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream(jsonFile)
                ?? throw new InvalidOperationException("Arquivo não encontrado.");

            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }

        public static XDocument GetXmlFileContent(string xmlFile)
        {
            using var stream =
                Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream(xmlFile)
                ?? throw new InvalidOperationException("Arquivo não encontrado.");

            using var reader = new StreamReader(stream);

            return XDocument.Load(stream);
        }

        public static Image GetImageFileContent(string imageFile)
        {
            using var stream =
                Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream(imageFile)
                ?? throw new InvalidOperationException("Imagem não encontrada.");

            using var reader = new StreamReader(stream);

            return Image.FromStream(stream);
        }
    }
}
