using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace ClockIt.src.Shared.Utils
{
    public static class FileHelper
    {
        public static string FindFileInProjectSync(string filename)
        {
            try
            {
                string directory = AppDomain.CurrentDomain.BaseDirectory;

                while (!Directory.Exists(Path.Combine(directory, "src")) && Directory.GetParent(directory) != null)
                {
                    directory = Directory.GetParent(directory)?.FullName!;
                }

                string? filePath = SearchFileInDirectory(directory, filename).GetAwaiter().GetResult();

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

        public static async Task<string> FindFileInProject(string filename)
        {
            try
            {
                string directory = AppDomain.CurrentDomain.BaseDirectory;

                while (!Directory.Exists(Path.Combine(directory, "src")) && Directory.GetParent(directory) != null)
                {
                    directory = Directory.GetParent(directory)?.FullName!;
                }

                string? filePath = await SearchFileInDirectory(directory, filename);

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

        private static async Task<string?> SearchFileInDirectory(string directoryPath, string filename)
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
                    string? foundFile = await SearchFileInDirectory(subDirectory, filename);
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
