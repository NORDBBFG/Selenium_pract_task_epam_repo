using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_pract_task.Entities
{
    public sealed class DriverManager
    {
        private static readonly Lazy<DriverManager> instance = new Lazy<DriverManager>(() => new DriverManager());
        private IWebDriver driver;

        private DriverManager() { }

        public static DriverManager Instance => instance.Value;

        public IWebDriver GetDriver(string browser, bool isHeadless, string baseUrl)
        {
            if (driver == null)
            {
                driver = BrowserFactory.CreateDriver(browser, isHeadless);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.Navigate().GoToUrl(baseUrl);
            }

            return driver;
        }

        public void QuitDriver()
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
