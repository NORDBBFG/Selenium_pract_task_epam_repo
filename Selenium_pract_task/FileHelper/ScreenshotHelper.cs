using OpenQA.Selenium;
using System.Text.RegularExpressions;
using static Selenium_pract_task.Logger.Logger;

namespace Selenium_pract_task.FileHelper
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(string testName, IWebDriver driver)
        {
            var logger = GetLogger();
            var sanitizedTestName = Regex.Replace(testName, @"[<>:""/\\|?*]", "_");

            try
            {
                if (driver is ITakesScreenshot screenshotDriver)
                {
                    var screenshot = screenshotDriver.GetScreenshot();
                    var screenshotFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "failedScreenshots");
                    Directory.CreateDirectory(screenshotFolderPath);

                    var filePath = Path.Combine(screenshotFolderPath, $"{sanitizedTestName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                    logger.Information($"Screenshot saved to {filePath}");
                }
            }
            catch (Exception e)
            {
                logger.Error($"Failed to take screenshot: {e.Message}");
            }
        }
    }
}
