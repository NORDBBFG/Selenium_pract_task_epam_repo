using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_pract_task.POM.UIElements.EpamContinuumComponent
{
    public class EpamCookiesConsentComponent : AbstractPageContext
    {
        public EpamCookiesConsentComponent(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ButtonAcceptAllCookies => driver.FindElement(By.XPath("//button[@id='onetrust-accept-btn-handler']"));
    }
}
