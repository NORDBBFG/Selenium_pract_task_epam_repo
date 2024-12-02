using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.EpamMainPage.UIElements.EpamContinuumElement
{
    public class EpamContinuumElement : AbstractPageContext
    {
        public EpamContinuumElement(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ContinuumTitle => driver.FindElement(By.XPath("//span[@class='font-size-80-33']//span"));
    }
}
