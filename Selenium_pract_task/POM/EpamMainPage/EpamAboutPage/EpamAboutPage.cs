using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.EpamMainPage.EpamAboutPage
{
    public class EpamAboutPage : AbstractPage
    {
        public EpamAboutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ButtonDownload => driver.FindElement(By.XPath("//a[@download]"));
    }
}
