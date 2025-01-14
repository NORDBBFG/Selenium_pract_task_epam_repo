using NUnit.Framework;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using Selenium_pract_task.FileHelper;
using static Selenium_pract_task.Constants.Constants.IOConstants;
using static Selenium_pract_task.FileHelper.ScreenshotHelper;
using NUnit.Framework.Interfaces;

namespace Selenium_pract_task.Entities.AbstractEntities
{
    [SetUpFixture]
    public abstract class BaseTest : LoggerSetUp
    {
        protected IWebDriver driver;
        private IConfiguration _browserConfig;
        private readonly string baseUrl = "https://www.epam.com";
        private string headlesRunStatus = "true";

        [SetUp]
        public void Setup()
        {
            try
            {
                logger.Information("Test setup started.");
                logger.Information("Reading browser configuration...");

                JsonHelper.EnsureJsonFileExists();
                EnvironmentVariableHelper.EnsureEnvironmentVariableExist(headlesStateEnvironmentVariableName, headlesRunStatus);
                
                var configPath = Path.Combine(Directory.GetCurrentDirectory(), "browserconfig.json");
                _browserConfig = new ConfigurationBuilder()
                    .AddJsonFile(configPath)
                    .Build();

                string browser = Environment.GetEnvironmentVariable("BROWSER") ?? _browserConfig["Browser"];
                bool isHeadless = Environment.GetEnvironmentVariable("HEADLESS")?.ToLower() == "true";
                
                driver = DriverManager.Instance.GetDriver(browser, isHeadless, baseUrl);

                logger.Information($"Browser initialized: {browser}, Headless mode: {isHeadless}");
            }
            catch (Exception ex)
            {
                logger.Error($"Error during test setup: {ex.Message}");
                throw;
            }
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    string testName = TestContext.CurrentContext.Test.Name;
                    logger.Error($"Test failed: {testName}");

                    TakeScreenshot(testName, driver);

                    logger.Information($"Screenshot taken for failed test: {testName}");
                }
                else
                {
                    logger.Information($"Test passed: {TestContext.CurrentContext.Test.Name}");
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error during test teardown: {ex.Message}");
            }
            finally
            {
                DriverManager.Instance.QuitDriver();
                logger.Information("Driver closed.");
            }
        }
    }
}
