using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using NUnit.Framework;

namespace Selenium_pract_task.POM.EpamMainPage.EpamSearchPage
{
    public class EpamSearchPageContext : AbstractPageContext
    {
        private EpamSearchPage epamSearchPage;

        public EpamSearchPageContext(IWebDriver driver)
        {
            this.driver = driver;
            epamSearchPage = new EpamSearchPage(driver);
        }

        public EpamSearchPageContext VerifyAllSerchedLinksContainsValue(string value, bool expectedResult = true)
        {
            epamSearchPage.FoundLinks
        .Select(link => link.Text.ToLower())
        .ToList()
        .ForEach(linkText =>
            Assert.That(expectedResult, Is.EqualTo(linkText.Contains(value.ToLower())),
                $"Link text: [{linkText}], do not contains expected value: [{value}]."));

            return this;
        }
    }
}
