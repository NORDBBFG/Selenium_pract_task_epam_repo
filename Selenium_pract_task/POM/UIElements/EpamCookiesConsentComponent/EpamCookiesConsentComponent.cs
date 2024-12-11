using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.UIElements.EpamContinuumComponent
{
    public class EpamCookiesConsentComponent : AbstractPage
    {
        public EpamCookiesConsentComponent(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ButtonAcceptAllCookies => driver.FindElement(By.XPath("//button[@id='onetrust-accept-btn-handler']"));
    }
}
