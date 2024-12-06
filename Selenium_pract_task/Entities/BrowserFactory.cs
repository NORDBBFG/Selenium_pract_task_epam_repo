using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Selenium_pract_task.Entities
{
    public static class BrowserFactory
    {
        public static IWebDriver CreateDriver(string browser, bool isHeadless)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    if (isHeadless)
                    {
                        chromeOptions.AddArgument("--headless");
                        chromeOptions.AddArgument("--disable-gpu");
                        chromeOptions.AddArgument("--window-size=1920,1080");
                    }
                    return new ChromeDriver(chromeOptions);

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    if (isHeadless)
                    {
                        firefoxOptions.AddArgument("--headless");
                        firefoxOptions.AddArgument("--window-size=1920,1080");
                    }
                    return new FirefoxDriver(firefoxOptions);

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    if (isHeadless)
                    {
                        edgeOptions.AddArgument("headless");
                        edgeOptions.AddArgument("disable-gpu");
                        edgeOptions.AddArgument("window-size=1920,1080");
                    }
                    return new EdgeDriver(edgeOptions);

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }
        }
    }
}
