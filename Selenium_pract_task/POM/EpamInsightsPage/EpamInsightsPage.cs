using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.UIElements.EpamContinuumElement;

namespace Selenium_pract_task.POM.EpamInsightsPage
{
    public class EpamInsightsPage : AbstractPage
    {
        public EpamContinuumSliderComponent epamContinuumSliderElement;
        public EpamInsightsPage(IWebDriver driver) : base(driver)
        {
            epamContinuumSliderElement = new EpamContinuumSliderComponent(driver);
        }
    }
}
