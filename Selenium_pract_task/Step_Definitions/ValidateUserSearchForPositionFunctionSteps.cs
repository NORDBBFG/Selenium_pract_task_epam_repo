using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamCareersPage;
using Selenium_pract_task.POM.EpamJobPage;
using Selenium_pract_task.POM.EpamMainPage;
using TechTalk.SpecFlow;

namespace Selenium_pract_task.Step_Definitions
{
    [Binding]
    public class ValidateUserSearchForPositionFunctionSteps : BaseTest
    {
        [When("I click on the 'Careers' link in the main navigation menu")]
        public void WhenIClickOnCareersLinkInTheMainNavigationMenu()
        {
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.ClickOnCareersLink();
        }

        [When("I check the remout check box")]
        public void WhenICheckTheRemoteCheckBox()
        {
            var epamCareersPageContext = new EpamCareersPageContext(driver);
            epamCareersPageContext.ScrollToCheckBoxRemote()
                .CheckRemoutCheckBox();
        }

        [When("I fill input search field with programming language (.+)")]
        public void WhenIFillInputSearchFieldWithProgrammingLanguage(string programingLanguage)
        {
            var epamCareersPageContext = new EpamCareersPageContext(driver);
            epamCareersPageContext.FillInputKeyword(programingLanguage);
        }

        [When("I select 'All Locations' in location drop down menu")]
        public void WhenISelectAllLocationsInLocationDropDownMenu()
        {
            var epamCareersPageContext = new EpamCareersPageContext(driver);
            epamCareersPageContext.ClickInputLocation()
                .SelectInputLocationAllLocations();
        }

        [Then("I click button 'Find'")]
        public void ThenIClickButtonFind()
        {
            var epamCareersPageContext = new EpamCareersPageContext(driver);
            epamCareersPageContext.ClickButtonFind();
        }

        [Then("I click button 'View and apply' on the last element found")]
        public void ThenIClickButtonViewAndApplyOnTheLastElementFound()
        {
            var epamCareersPageContext = new EpamCareersPageContext(driver);
            epamCareersPageContext.ClickButtonViewAndApplyLastElement();
        }

        [Then("I verify job title contains programmin language (.+)")]
        public void ThenIVerifyJobTitleContainsProgrammingLanguage(string programingLanguage)
        {
            var epamJobPageContext = new EpamJobPageContext(driver);
            epamJobPageContext.VerifyJobTitleContainsPrograminLanguage(programingLanguage);
        }
    }
}
