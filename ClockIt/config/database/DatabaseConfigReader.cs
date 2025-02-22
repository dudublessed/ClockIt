using System;
using System.Xml;

public class DatabaseConfigReader
{
    private static string _connectionString;

    public static string GetConnectionString()
    {
        if (!string.IsNullOrEmpty(_connectionString))
        {
            return _connectionString;
        }

        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(@".config/db/DatabaseConfig.xml");

            XmlNode node = xmlDoc.SelectSingleNode("//DatabaseConfig/ConnectionString");

            if (node == null) throw new Exception(ExceptionHandler.GetErrorMessages(4161));

            _connectionString = node.InnerText;
            return _connectionString;

        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionHandler.GetErrorMessages(5161));
        }
    }


}