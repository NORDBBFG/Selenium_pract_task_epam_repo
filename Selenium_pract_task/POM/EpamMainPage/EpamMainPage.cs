using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.UIElements.EpamHedderLinksComponent;

namespace Selenium_pract_task.POM.EpamMainPage
{
    public class EpamMainPage : AbstractPage
    {
        public EpamHedderLinksComponent epamHedderLinksComponent;

        public EpamMainPage(IWebDriver driver) : base(driver)
        {
            epamHedderLinksComponent = new EpamHedderLinksComponent(driver);
        }
    }
}
