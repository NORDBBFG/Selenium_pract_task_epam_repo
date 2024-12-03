using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.EpamMainPage.EpamJobPage
{
    public class EpamJobPage : AbstractPage
    {
        public EpamJobPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement JobeTitle => driver.FindElement(By.XPath("//h1[@class='vacancy-details-23__job-title']"));
    }
}
