using NUnit.Framework;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage;

namespace Selenium_pract_task.Tets_Cases
{
    public class Validate_global_search_works_as_expected : BaseTest
    {
        [Test]
        public void Test1()
        {
            //Arrange
            string programinLanguage;

            //Act
            programinLanguage = "Java";

            //Assert
            driver.Navigate().GoToUrl("https://www.epam.com/");
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.VerifyCookiesHandler()
                .ClickOnIconMagnifier()
                .SetTextInputSearchField("Automation")
                .ClickButtonFind()
                .VerifyAllSerchedLinksContainsValue("Automation");
        }
    }
}
