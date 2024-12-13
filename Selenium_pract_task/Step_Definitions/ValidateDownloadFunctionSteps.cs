using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage;
using static Selenium_pract_task.Constants.Constants.IOConstants;
using static Selenium_pract_task.FileHelper.FileHelper;
using TechTalk.SpecFlow;
using Selenium_pract_task.POM.EpamAboutPage;
using NUnit.Framework;

namespace Selenium_pract_task.Step_Definitions
{
    [Binding]
    public class ValidateDownloadFunctionSteps : BaseTest
    {
        [Given("I navigate to the EPAM website")]
        public void GivenINavigateToTheEPAMWebsite()
        {
            var epamMainPageContext = new EpamMainPageContext(driver);
            driver.Navigate().GoToUrl(EPAMBaseUrl);
            epamMainPageContext.VerifyCookiesHandler<EpamMainPageContext>();
        }

        [When("I click on 'About' link in the main navigation menu")]
        public void WhenIClickOnAboutLinkInTheMainNavigationMenu()
        {
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.ClickOnAboutLink();
        }

        [When("I click on 'Download' button")]
        public void WhenIClickOnDownloadButton()
        {
            var epamAboutPageContext = new EpamAboutPageContext(driver);
            epamAboutPageContext.ClickButtonDownload();
        }

        [Then(@"I validate that downloaded file name is '(.*)'")]
        public void ThenIValidateThatDownloadedFileNameIs(string expectedFileName)
        {
            string filePath = Path.Combine(windowsDefaultDownloadDirectoryPath, expectedFileName);
            var actualResult = WaitForFileExist(filePath, 5);
            Assert.That(true, Is.EqualTo(actualResult), $"File [{expectedFileName}] using file path: [{filePath}] was not found.");
        }
    }
}
