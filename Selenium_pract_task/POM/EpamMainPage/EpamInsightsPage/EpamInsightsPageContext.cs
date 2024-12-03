using NUnit.Framework;
using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage.EpamInsightsPage.EpamResearchResultsPage;
using Selenium_pract_task.POM.EpamMainPage.UIElements.EpamContinuumElement;

namespace Selenium_pract_task.POM.EpamMainPage.EpamInsightsPage
{
    public class EpamInsightsPageContext : AbstractPageContext
    {
        private EpamInsightsPage epamInsightsPage;
        private EpamContinuumSliderElement epamContinuumElement;

        public EpamInsightsPageContext(IWebDriver driver) : base(driver)
        {
            epamInsightsPage = new EpamInsightsPage(driver);
            epamContinuumElement = new EpamContinuumSliderElement(driver);
        }

        public EpamInsightsPageContext ClickButtonNextSlideContinuum(int clicks = 1)
        {
            for (int i = 0; i < clicks; i++)
            {
                epamInsightsPage.epamContinuumSliderElement.ButtonNextContinuumSlider.Click();
            }

            return this;
        }

        public EpamResearchResultsPageContext ClickButtonReadMoreContinuum()
        {
            epamInsightsPage.epamContinuumSliderElement.ButtonReadMoreContinuumSlider.Click();
            return new EpamResearchResultsPageContext(driver);
        }

        public EpamInsightsPageContext GetTextActiveSliderContinuum(out string activeSliderPreview)
        {
            Thread.Sleep(1000);
            activeSliderPreview = epamInsightsPage.epamContinuumSliderElement.ActiveTextContinuumSlider.Text;
            return this;
        }
    }
}
