using NUnit.Framework;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamArtificialIntelligencePage;
using Selenium_pract_task.POM.EpamMainPage;
using TechTalk.SpecFlow;

namespace Selenium_pract_task.Step_Definitions
{
    [Binding]
    public class ValidateNavigationToServicesSectionSteps : BaseTest
    {
        [When("I click on the 'Services' link in the main navigation menu")]
        public void WhenIClickOnTheServicesLinkInTheMainNavigationMenu()
        {
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.ClickOnLinkServices();
        }

        [When(@"I click on a specific service category (.+) from the Services dropdown")]
        public void WhenIClickOnASpecificServiceCategoryFromTheServicesDropdown(string category)
        {
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.ClickOnLinkServicesAiType(category);
        }

        [Then(@"I validate that the page contains the correct title: (.+)")]
        public void ThenIValidateThatThePageContainsTheCorrectTitle(string expectedTitle)
        {
            var epamArtificialIntelligencePageContext = new EpamArtificialIntelligencePageContext(driver);
            var title = epamArtificialIntelligencePageContext.GetAiPageTitleText(expectedTitle);
            var actualResult = title.Contains(expectedTitle.ToLower());
            Assert.That(true, Is.EqualTo(actualResult), $"AiPage title: [{title}], do not contains expected value: [{expectedTitle}].");

        }

        [Then("I validate that the section 'Our Related Expertise' is displayed on the page")]
        public void ThenIValidateThatTheSectionOurRelatedExpertiseIsDisplayedOnThePage()
        {
            var epamArtificialIntelligencePageContext = new EpamArtificialIntelligencePageContext(driver);
            var actualResult = epamArtificialIntelligencePageContext.VerifyOurRelatedExpertiseSectionExist();
            Assert.That(true, Is.EqualTo(actualResult), $"Our Related Expertise Section is not displayed on the page");

        }
    }
}
