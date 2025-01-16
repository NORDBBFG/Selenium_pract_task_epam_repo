using System.IO;

namespace Selenium_pract_task.FileHelper
{
    public static class FileHelper
    {
        public static bool WaitForFileExist(string filePath, int timeoutSeconds = 30)
        {
            DateTime startTime = DateTime.Now;

            while ((DateTime.Now - startTime).TotalSeconds < timeoutSeconds)
            {
                if (File.Exists(filePath))
                {
                    return true;
                }

                Thread.Sleep(1000);
            }

            return false;
        }

        public static void EnsureDirectoryExist(string filePath, string fileName)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name cannot be null or empty.", nameof(fileName));
            }

            try
            {
                string fullPath = Path.Combine(filePath, fileName);
                string absolutePath = Path.GetFullPath(fullPath);

                if (!DirectoryExists(absolutePath))
                {
                    Directory.CreateDirectory(absolutePath);
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Error creating directory at {filePath}.", ex);
            }
        }

        public static bool DirectoryExists(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            return Directory.Exists(filePath);
        }
    }
}
