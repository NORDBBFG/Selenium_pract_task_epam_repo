using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage.UIElements.EpamContinuumElement;

namespace Selenium_pract_task.POM.EpamMainPage.EpamInsightsPage
{
    public class EpamInsightsPage : AbstractPage
    {
        public EpamContinuumSliderElement epamContinuumSliderElement;
        public EpamInsightsPage(IWebDriver driver) : base(driver)
        {
            epamContinuumSliderElement = new EpamContinuumSliderElement(driver);
        }
    }
}
