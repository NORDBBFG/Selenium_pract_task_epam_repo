using NUnit.Framework;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using Selenium_pract_task.FileHelper;
using static Selenium_pract_task.Constants.Constants.IOConstants;
using static Selenium_pract_task.FileHelper.ScreenshotHelper;
using NUnit.Framework.Interfaces;
using static Selenium_pract_task.Logger.Logger;
using TechTalk.SpecFlow;

namespace Selenium_pract_task.Entities.AbstractEntities
{
    [Binding]
    public abstract class BaseTest
    {
        protected static IWebDriver driver;
        private static IConfiguration _browserConfig;
        private static string headlesRunStatus = "true";

        [BeforeTestRun]
        public static void GlobalSetup()
        {
            InitializeLogger();
            var logger = GetLogger();

            logger.Information("Global setup started.");
            logger.Information("Reading browser configuration...");
        }

        [BeforeFeature]
        public static void Setup()
        {
            var logger = GetLogger();

            try
            {
                logger.Information("Test setup started.");

                JsonHelper.EnsureJsonFileExists();
                EnvironmentVariableHelper.EnsureEnvironmentVariableExist(headlesStateEnvironmentVariableName, headlesRunStatus);
                var configPath = Path.Combine(Directory.GetCurrentDirectory(), "browserconfig.json");
                _browserConfig = new ConfigurationBuilder()
                    .AddJsonFile(configPath)
                    .Build();
                string browser = _browserConfig["Browser"];
                bool isHeadless = Environment.GetEnvironmentVariable("HEADLESS")?.ToLower() == "true";
                driver = DriverManager.Instance.GetDriver(browser, isHeadless);

                logger.Information($"Browser initialized: {browser}, Headless mode: {isHeadless}");
            }
            catch (Exception ex)
            {
                logger.Error($"Error during test setup: {ex.Message}");
                throw;
            }
        }

        [AfterFeature]
        public static void TearDown()
        {
            var logger = GetLogger();

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

            [AfterTestRun]
        public static void GlobalTearDown()
        {
            var logger = GetLogger();
            logger.Information("Global teardown completed.");
        }
    }
}
