using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using Selenium_pract_task.FileHelper;

namespace Selenium_pract_task.Entities.AbstractEntities
{
    [SetUpFixture]
    public abstract class BaseTest
    {
        protected IWebDriver driver;
        private IConfiguration _browserConfig;
        private readonly string baseUrl = "https://www.epam.com";

        [SetUp]
        public void Setup()
        {
            JsonHelper.EnsureJsonFileExists();
            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "browserconfig.json");
            _browserConfig = new ConfigurationBuilder()
                .AddJsonFile(configPath)
                .Build();

            string browser = _browserConfig["Browser"];

            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    driver = new FirefoxDriver(firefoxOptions);
                    break;
                case "edge":
                    var edgeOptions = new EdgeOptions();
                    driver = new EdgeDriver(edgeOptions);
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl(baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}
