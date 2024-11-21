using NUnit.Framework;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage;
using Selenium_pract_task.POM.EpamMainPage.EpamCareersPage;

namespace Selenium_pract_task.Tets_Cases
{
    public class Tests : BaseTest
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
            Thread.Sleep(3000);
            epamMainPageContext.clickOnCareersLink()
                .verifyCookiesHendler()
                .ScrolePage<EpamCareersPageContext>(8)
                .checkRemoutCheckBox()
                .fillInputKeyword(programinLanguage)
                .clickInputLocation()
                .selectInputLocationAllLocations()
                .clickButtonFind()
                .clickButtonViewAndApplyLastElement()
                .verifyJobTitleContainsValue(programinLanguage);
        }
    }
}
