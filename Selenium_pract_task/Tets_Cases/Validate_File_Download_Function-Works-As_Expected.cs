using NUnit.Framework;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage;
using static Selenium_pract_task.Constants.Constants.IOConstants;

namespace Selenium_pract_task.Tets_Cases
{
    [TestFixture]
    public class Validate_File_Download_Function_Works_As_Expected : BaseTest
    {

        [TestCase(EPAMCorporateOverviewFileNeame)]
        public void ValidateFileDownloadFunction(string downloadedFileName)
        {
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.VerifyCookiesHandler<EpamMainPageContext>()
                .ClickOnAboutLink()
                .ClickButtonDownload()
                .VerifyEPAMCompanyOverviewDownloadedFileExist(downloadedFileName);
        }

        [TearDown]
        public void TearDown()
        {
            string filePath = Path.Combine(windowsDefaultDownloadDirectoryPath, EPAMCorporateOverviewFileNeame);
            File.Delete(filePath);
        }
    }
}
