using NUnit.Framework;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage;
using Selenium_pract_task.POM.EpamMainPage.EpamCareersPage;

namespace Selenium_pract_task.Tets_Cases
{
    public class Validate_that_user_can_search_for_a_position_based_on_criteria : BaseTest
    {
        [TestCase("Java")]
        [TestCase(".Net")]
        [TestCase("JavaScript")]
        public void TestUserPositionSearchBasedOnCriteriaFunctionality(string programinLanguage)
        {
            driver.Navigate().GoToUrl("https://www.epam.com/");
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.VerifyCookiesHandler()
                .ClickOnCareersLink()
                .ScrolePage<EpamCareersPageContext>(8)
                .CheckRemoutCheckBox()
                .FillInputKeyword(programinLanguage)
                .ClickInputLocation()
                .SelectInputLocationAllLocations()
                .ClickButtonFind()
                .ClickButtonViewAndApplyLastElement()
                .VerifyJobTitleContainsValue(programinLanguage);
        }
    }
}
