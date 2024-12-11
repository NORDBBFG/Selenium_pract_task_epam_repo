using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.UIElements.EpamHedderLinksComponent
{
    public class EpamHedderLinksComponent : AbstractPage
    {
        public EpamHedderLinksComponent(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement LinkServices => driver.FindElement(By.LinkText("Services"));
        public IWebElement LinkServicesAiType(string aiType) => driver.FindElement(By.LinkText(aiType));
    }
}
