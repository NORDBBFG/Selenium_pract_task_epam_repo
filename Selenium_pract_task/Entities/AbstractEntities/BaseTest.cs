using NUnit.Framework;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using Selenium_pract_task.FileHelper;
using static Selenium_pract_task.Constants.Constants.IOConstants;
using static Selenium_pract_task.FileHelper.ScreenshotHelper;
using NUnit.Framework.Interfaces;
using static Selenium_pract_task.Logger.Logger;

namespace Selenium_pract_task.Entities.AbstractEntities
{
    [SetUpFixture]
    public abstract class BaseTest
    {
        protected IWebDriver driver;
        private IConfiguration _browserConfig;
        private readonly string baseUrl = "https://www.epam.com";
        private string headlesRunStatus = "true";

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            InitializeLogger();
            var logger = GetLogger();

            logger.Information("Global setup started.");
            logger.Information("Reading browser configuration...");
        }

        [SetUp]
        public void Setup()
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

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            var logger = GetLogger();
            logger.Information("Global teardown completed.");
        }
    }
}
