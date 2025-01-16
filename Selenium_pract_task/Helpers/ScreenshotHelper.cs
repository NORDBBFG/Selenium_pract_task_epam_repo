using OpenQA.Selenium;
using System.Text.RegularExpressions;
using static Selenium_pract_task.Logger.Logger;
using static Selenium_pract_task.Constants.Constants.IOConstants;

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
                    var artifactFoulderPath = Path.Combine(currentProjectBaseDirectory, "ArtifactsFoulder");
                    Directory.CreateDirectory(screenshotFolderPath);

                    var filePath = Path.Combine(screenshotFolderPath, $"{sanitizedTestName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                    var artifactFilePath = Path.Combine(artifactFoulderPath, $"{sanitizedTestName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                    screenshot.SaveAsFile(filePath);
                    screenshot.SaveAsFile(artifactFilePath);

                    logger.Information($"Screenshot saved to {filePath}");
                    logger.Information($"Screenshot saved to {artifactFilePath}");
                }
            }
            catch (Exception e)
            {
                logger.Error($"Failed to take screenshot: {e.Message}");
            }
        }
    }
}
