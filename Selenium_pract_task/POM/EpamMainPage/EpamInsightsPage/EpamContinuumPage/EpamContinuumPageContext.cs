using NUnit.Framework;
using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.EpamMainPage.EpamInsightsPage.EpamContinuumPage
{
    public class EpamContinuumPageContext : AbstractPageContext
    {
        private EpamContinuumPage epamContinuumPage;

        public EpamContinuumPageContext(IWebDriver driver) : base(driver)
        {
            epamContinuumPage = new EpamContinuumPage(driver);
        }

        public EpamContinuumPageContext VerifyCountinuumPageTitle(string expectedCountinuumTitle, bool expectedResult = true)
        {
            var actualCountinuumTitle = epamContinuumPage.ContinuumTitle.Text.Trim();
            var actualResult = actualCountinuumTitle.Equals(expectedCountinuumTitle.Trim());
            Assert.That(expectedResult, Is.EqualTo(actualResult), $"Job title: [{actualCountinuumTitle}], is not equals to expected value: [{expectedCountinuumTitle}].");
            return this;
        }
    }
}
