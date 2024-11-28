using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using static Selenium_pract_task.Constants.Constants.IOConstants;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace Selenium_pract_task.POM.EpamMainPage.EpamAboutPage
{
    public class EpamAboutPageContext : AbstractPageContext
    {
        EpamAboutPage epamAboutPage;

        private EpamMainPage epamMainPage;

        public EpamAboutPageContext(IWebDriver driver)
        {
            this.driver = driver;
            epamMainPage = new EpamMainPage(driver);
        }

        public EpamAboutPageContext ClickButtonDownload()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(epamAboutPage.ButtonDownload).Click().Perform();
            return this;
        }

        public EpamAboutPageContext VerifyEPAMCompanyOverviewDownloadedFileExist(string fileName, bool expectedResolt = true)
        {
            string filePath = Path.Combine(windowsDefaultDownloadDirectoryPath, fileName);
            var actualResult = File.Exists(filePath);
            Assert.That(expectedResolt, Is.EqualTo(actualResult), $"File [{fileName}] using file path: [{filePath}] was not found.");
            return this;
        }
    }
}
