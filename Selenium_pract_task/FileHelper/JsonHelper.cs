using Newtonsoft.Json;

namespace Selenium_pract_task.FileHelper
{
    public static class JsonHelper
    {
        public static void EnsureJsonFileExists()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "browserconfig.json");

            if (!File.Exists(filePath))
            {
                var defaultConfig = new
                {
                    Browser = "firefox"
                };

                string jsonContent = JsonConvert.SerializeObject(defaultConfig, Formatting.Indented);

                File.WriteAllText(filePath, jsonContent);
            }
        }
    }
}
