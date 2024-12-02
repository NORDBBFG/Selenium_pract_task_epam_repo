using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage.EpamInsightsPage.EpamContinuumPage;

namespace Selenium_pract_task.POM.EpamMainPage.EpamInsightsPage
{
    public class EpamInsightsPageContext : AbstractPageContext
    {
        private EpamInsightsPage epamInsightsPage;

        public EpamInsightsPageContext(IWebDriver driver) : base(driver)
        {
            epamInsightsPage = new EpamInsightsPage(driver);
        }

        public EpamInsightsPageContext ClickButtonNextSlideContinuum(int clicks = 1)
        {
            for (int i = 0; i < clicks; i++)
            {
                epamInsightsPage.ButtonNextContinuumSlider.Click();
            }

            return this;
        }

        public EpamContinuumPageContext ClickButtonReadMoreContinuum()
        {
            epamInsightsPage.ButtonReadMoreContinuumSlider.Click();
            return new EpamContinuumPageContext(driver);
        }

        public EpamInsightsPageContext GetTextActiveSliderContinuum(out string activeSliderPreview)
        {
            Thread.Sleep(1000);
            activeSliderPreview = epamInsightsPage.ActiveTextContinuumSlider.Text;
            return this;
        }
    }
}
