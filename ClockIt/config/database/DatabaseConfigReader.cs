using System;
using System.Xml;
using System.Xml.Linq;
using ClockIt.src.Shared.Utils;

public class DatabaseConfigReader
{
    private static string _connectionString;
    private static readonly object _lock = new object();

    public static string GetConnectionString()
    {
        if (!string.IsNullOrEmpty(_connectionString))
        {
            return _connectionString;
        }

        lock (_lock)
        {
            if(!string.IsNullOrEmpty(_connectionString))
            {
                return _connectionString;
            }

            try
            {
                string pathToFile = FileHelper.FindFileInProject("DatabaseConfig.xml");

                if (string.IsNullOrEmpty(pathToFile) || !System.IO.File.Exists(pathToFile))
                {
                    throw new Exception(ExceptionHandler.GetErrorMessages(4003));
                }

                XDocument xmlDoc = XDocument.Load(pathToFile);

                var node = xmlDoc.Descendants("DBConnectionString").FirstOrDefault();

                if (string.IsNullOrWhiteSpace(node.Value))
                {
                    throw new Exception(ExceptionHandler.GetErrorMessages(4001));
                }

                _connectionString = node.Value;
                return _connectionString;

            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHandler.GetErrorMessages(5001));
            }
        }
    }


}