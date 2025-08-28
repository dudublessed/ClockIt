using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace ClockIt.src.Shared.Utils
{
    public static class FileHelper
    {
        public static string FindFileInProject(string filename, string? searchDirectory = null)
        {
            try
            {
                string directory = AppDomain.CurrentDomain.BaseDirectory;

                while (!Directory.Exists(Path.Combine(directory, "src")) && Directory.GetParent(directory) != null)
                {
                    directory = Directory.GetParent(directory)?.FullName!;
                }

                string filePath = SearchFileInDirectory(directory, filename);

                if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
                {
                    throw new FileNotFoundException($"{filename} was not found in project.");
                }

                return filePath;
            } 
            catch (Exception ex)
            {
                throw new FileNotFoundException($"{filename} was not found in project.");
            }
        }

        private static string SearchFileInDirectory(string directoryPath, string filename)
        {
            try
            {
                string[] files = Directory.GetFiles(directoryPath, filename, SearchOption.TopDirectoryOnly);

                if (files.Length > 0)
                {
                    return files[0];
                }

                string[] subdirectories = Directory.GetDirectories(directoryPath);
                foreach(var subDirectory in subdirectories)
                {
                    string? foundFile = SearchFileInDirectory(subDirectory, filename);
                    if (foundFile != null)
                    {
                        return foundFile;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
