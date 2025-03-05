using System;
using System.Xml;
using System.Xml.Linq;
using ClockIt.Core.Utils;

public class DatabaseConfigReader
{
    private static string _connectionString;
    private static string? _pathtofile;

    public static string GetConnectionString()
    {
        if (!string.IsNullOrEmpty(_connectionString))
        {
            return _connectionString;
        }

        try
        {
            _pathtofile = FileHelper.FindFileInProject("DatabaseConfig.xml");

            XDocument xmlDoc = XDocument.Load(_pathtofile);

            var node = xmlDoc.Descendants("DBConnectionString").FirstOrDefault();

            if (string.IsNullOrWhiteSpace(node.Value))
            {
                throw new Exception(ExceptionHandler.GetErrorMessages(4161));
            }

            _connectionString = node.Value;
            return _connectionString;

        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionHandler.GetErrorMessages(5161));
        }
    }


}