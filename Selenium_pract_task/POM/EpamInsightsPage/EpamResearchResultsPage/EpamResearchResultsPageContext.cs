using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.EpamInsightsPage.EpamResearchResultsPage
{
    public class EpamResearchResultsPageContext : AbstractPageContext
    {
        private EpamResearchResultsPage epamResearchResultsPage;

        public EpamResearchResultsPageContext(IWebDriver driver) : base(driver)
        {
            epamResearchResultsPage = new EpamResearchResultsPage(driver);
        }

        public bool VerifyCountinuumPageTitleExist(string expectedCountinuumTitle, out string actualCountinuumTitle)
        {
            actualCountinuumTitle = epamResearchResultsPage.ContinuumTitle.Text.Trim();
            var actualResult = actualCountinuumTitle.Equals(expectedCountinuumTitle.Trim());
            return actualResult;
        }
    }
}
