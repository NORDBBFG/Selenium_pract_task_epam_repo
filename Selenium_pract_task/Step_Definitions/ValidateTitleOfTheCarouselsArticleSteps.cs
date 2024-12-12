using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamInsightsPage;
using Selenium_pract_task.POM.EpamInsightsPage.EpamResearchResultsPage;
using Selenium_pract_task.POM.EpamMainPage;
using TechTalk.SpecFlow;

namespace Selenium_pract_task.Step_Definitions
{
    [Binding]
    public class ValidateTitleOfTheCarouselsArticleSteps : BaseTest
    {
        [When("I click on 'Insights' link")]
        public void WhenIClickOnInsightsLink()
        {
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.ClickOnLinkInsightsLink();
        }

        [When("I click the 'Next' button in the Continuum slider two tims")]
        public void WhenIClickTheNextButtonInTheContinuumSlider()
        {
            var epamInsightPageContext = new EpamInsightsPageContext(driver);
            epamInsightPageContext.ClickButtonNextSlideContinuum(2);
        }

        [When("I get the active slider text")]
        public void WhenIGetTheActiveSliderText()
        {
            var epamInsightPageContext = new EpamInsightsPageContext(driver);
            string activeSliderText = epamInsightPageContext.GetTextActiveSliderContinuum();
            ScenarioContext.Current["ActiveSliderText"] = activeSliderText;
        }

        [When("I click on 'Read More' button")]
        public void WhenIClickOnReadMoreButton()
        {
            var epamInsightPageContext = new EpamInsightsPageContext(driver);
            epamInsightPageContext.ClickButtonReadMoreContinuum();
        }

        [Then("I validate that the Continuum page title matches the active slider text")]
        public void ThenIValidateThatTheContinuumPageTitleMatchesTheActiveSliderText()
        {
            var epamResearchResultsPageContext = new EpamResearchResultsPageContext(driver);
            string activeSliderText = (string)ScenarioContext.Current["ActiveSliderText"];
            epamResearchResultsPageContext.VerifyCountinuumPageTitle(activeSliderText);
        }
    }
}
