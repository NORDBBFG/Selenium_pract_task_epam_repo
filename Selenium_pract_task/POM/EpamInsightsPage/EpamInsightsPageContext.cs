using NUnit.Framework;
using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamInsightsPage.EpamResearchResultsPage;
using Selenium_pract_task.POM.UIElements.EpamContinuumSliderComponent;

namespace Selenium_pract_task.POM.EpamInsightsPage
{
    public class EpamInsightsPageContext : AbstractPageContext
    {
        private EpamInsightsPage epamInsightsPage;
        private EpamContinuumSliderComponent epamContinuumElement;

        public EpamInsightsPageContext(IWebDriver driver) : base(driver)
        {
            epamInsightsPage = new EpamInsightsPage(driver);
            epamContinuumElement = new EpamContinuumSliderComponent(driver);
        }

        public EpamInsightsPageContext ClickButtonNextSlideContinuum(int clicks = 1)
        {
            for (int i = 0; i < clicks; i++)
            {
                epamInsightsPage.epamContinuumSliderElement.ButtonNextContinuumSlider.Click();
            }
            logger.Information($"Button Next Slide where clicked [{clicks}] tims.");
            return this;
        }

        public EpamResearchResultsPageContext ClickButtonReadMoreContinuum()
        {
            epamInsightsPage.epamContinuumSliderElement.ButtonReadMoreContinuumSlider.Click();
            logger.Information("Button Read More Continuum where clicked.");
            return new EpamResearchResultsPageContext(driver);
        }

        public string GetTextActiveSliderContinuum()
        {
            Thread.Sleep(1000);
            var activeSliderPreview = epamInsightsPage.epamContinuumSliderElement.ActiveTextContinuumSlider.Text;
            logger.Information($"Text [{activeSliderPreview}] from active continuum slider where taken.");
            return activeSliderPreview;
        }
    }
}
