using NUnit.Framework;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage;

namespace Selenium_pract_task.Tets_Cases
{
    public class Validate_global_search_works_as_expected : BaseTest
    {
        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]
        public void TestGlobalSearchFunctionality(string searchFieldValue)
        {
            driver.Navigate().GoToUrl("https://www.epam.com/");
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.VerifyCookiesHandler()
                .ClickOnIconMagnifier()
                .SetTextInputSearchField(searchFieldValue)
                .ClickButtonFind()
                .VerifyAllSerchedLinksContainsValue(searchFieldValue);
        }
    }
}
