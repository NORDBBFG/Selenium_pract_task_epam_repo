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
    }
}
