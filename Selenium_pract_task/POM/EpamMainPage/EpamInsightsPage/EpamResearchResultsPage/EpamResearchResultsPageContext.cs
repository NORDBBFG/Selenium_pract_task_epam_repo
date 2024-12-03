using NUnit.Framework;
using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.EpamMainPage.EpamInsightsPage.EpamResearchResultsPage
{
    public class EpamResearchResultsPageContext : AbstractPageContext
    {
        private EpamResearchResultsPage epamResearchResultsPage;

        public EpamResearchResultsPageContext(IWebDriver driver) : base(driver)
        {
            epamResearchResultsPage = new EpamResearchResultsPage(driver);
        }

        public EpamResearchResultsPageContext VerifyCountinuumPageTitle(string expectedCountinuumTitle, bool expectedResult = true)
        {
            var actualCountinuumTitle = epamResearchResultsPage.ContinuumTitle.Text.Trim();
            var actualResult = actualCountinuumTitle.Equals(expectedCountinuumTitle.Trim());
            Assert.That(expectedResult, Is.EqualTo(actualResult), $"Job title: [{actualCountinuumTitle}], is not equals to expected value: [{expectedCountinuumTitle}].");
            return this;
        }
    }
}
