using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using ClockIt.src.Shared.Utils;

public class ExceptionHandler
{
    private static string? _pathtofile;

    public static string GetErrorMessages(int exceptionCode)
    {
        try
        {
            _pathtofile = FileHelper.FindFileInProject("ExceptionsPattern.xml");

            if (string.IsNullOrEmpty(_pathtofile) || !File.Exists(_pathtofile))
            {
                return "Error file not found or path is invalid.";
            }

            XDocument xmlDoc = XDocument.Load(_pathtofile);

            var exception = xmlDoc.Descendants("Exception")
                                         .FirstOrDefault(e => (string)e.Attribute("id") == exceptionCode.ToString());

            if (exception == null) return "Non-existent Error OR Error not found.";

            string exceptionMessage = exception.Element("Message").Value;
            string exceptionPrognosticCode = exception.Element("PrognosticCode").Value;

            string givenErrorMessage = $"Exception: {exceptionMessage}.\nP.C: {exceptionPrognosticCode}";

            return givenErrorMessage;
        }
        catch (Exception ex)
        {
            return $"Fatal error: {ex.Message}";
        }
    }
}