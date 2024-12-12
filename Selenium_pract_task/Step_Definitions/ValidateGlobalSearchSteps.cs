using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage;
using Selenium_pract_task.POM.EpamSearchPage;

using TechTalk.SpecFlow;

namespace Selenium_pract_task.Step_Definitions
{
    [Binding]
    public class ValidateGlobalSearchSteps : BaseTest
    {
        [When("I click on 'Magnifier' icon")]
        public void WhenIClickOnTheMagnifierIcon()
        {
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.ClickOnIconMagnifier();
        }

        [When(@"I set text (.+) to 'Input' search field")]
        public void WhenISetTextToTheInputSearchField(string searchFieldValue)
        {
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.SetTextInputSearchField(searchFieldValue);
        }

        [Then("I click 'Find' button")]
        public void ThenIClickTheFindButton()
        {
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.ClickButtonFind();
        }

        [Then(@"I validate that all searched links contain (.+)")]
        public void ThenIValidateThatAllSearchedLinksContain(string searchFieldValue)
        {
            var epamSearchPageContext = new EpamSearchPageContext(driver);
            epamSearchPageContext.VerifyAllSerchedLinksContainsSerchedText(searchFieldValue);
        }
    }
}
