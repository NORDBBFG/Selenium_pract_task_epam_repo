using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Selenium_pract_task.POM.EpamMainPage.EpamSearchPage
{
    internal class EpamSearchPageContext : AbstractPageContext
    {
        private EpamSearchPage epamSearchPage;

        public EpamSearchPageContext(IWebDriver driver)
        {
            this.driver = driver;
            epamSearchPage = new EpamSearchPage(driver);
        }

        public EpamSearchPageContext VerifyAllSerchedLinksContainsValue(string value, bool expectedResult = true)
        {
            foreach (var link in epamSearchPage.FoundLinks)
            {
                string linkText = link.Text;
                var actualResult = linkText.Contains(value);
                Assert.That(expectedResult, Is.EqualTo(actualResult), $"Link text: [{linkText}], do not contains expected value: [{value}].");
            }

            return this;
        }
    }
}
