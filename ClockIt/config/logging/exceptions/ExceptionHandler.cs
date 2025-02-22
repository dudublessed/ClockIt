using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.IO;

public class ExceptionHandler
{
    private static string _pathtofile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExceptionsPattern.xml");

    public static string GetErrorMessages(int exceptionCode)
    {
        try
        {
            XDocument xmlDoc = XDocument.Load(_pathtofile);

            var exception = xmlDoc.Descendants("Exception")
                                         .FirstOrDefault(e => (string)e.Attribute("id") == exceptionCode.ToString());

            if (exception == null) return "Non-existent Error OR Error not found.";

            string exceptionMessage = exception.Element("Message").Value;
            string exceptionPC = exception.Element("PC").Value;

            return exceptionMessage + exceptionPC;
        }
        catch (Exception ex)
        {
            return $"Fatal error: {ex.Message}";
        }
    }
}