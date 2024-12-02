using NUnit.Framework;
using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage.UIElements.EpamContinuumElement;

namespace Selenium_pract_task.POM.EpamMainPage.EpamInsightsPage
{
    public class EpamInsightsPageContext : AbstractPageContext
    {
        private EpamInsightsPage epamInsightsPage;
        private EpamContinuumElement epamContinuumElement;

        public EpamInsightsPageContext(IWebDriver driver) : base(driver)
        {
            epamInsightsPage = new EpamInsightsPage(driver);
            epamContinuumElement = new EpamContinuumElement(driver);
        }

        public EpamInsightsPageContext ClickButtonNextSlideContinuum(int clicks = 1)
        {
            for (int i = 0; i < clicks; i++)
            {
                epamInsightsPage.ButtonNextContinuumSlider.Click();
            }

            return this;
        }

        public EpamInsightsPageContext ClickButtonReadMoreContinuum()
        {
            epamInsightsPage.ButtonReadMoreContinuumSlider.Click();
            return this; ;
        }

        public EpamInsightsPageContext GetTextActiveSliderContinuum(out string activeSliderPreview)
        {
            Thread.Sleep(1000);
            activeSliderPreview = epamInsightsPage.ActiveTextContinuumSlider.Text;
            return this;
        }

        public EpamInsightsPageContext VerifyCountinuumPageTitle(string expectedCountinuumTitle, bool expectedResult = true)
        {
            var actualCountinuumTitle = epamContinuumElement.ContinuumTitle.Text.Trim();
            var actualResult = actualCountinuumTitle.Equals(expectedCountinuumTitle.Trim());
            Assert.That(expectedResult, Is.EqualTo(actualResult), $"Job title: [{actualCountinuumTitle}], is not equals to expected value: [{expectedCountinuumTitle}].");
            return this;
        }
    }
}
