using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenQA.Selenium.BiDi.Modules.BrowsingContext.Locator;

namespace Selenium_pract_task.POM.EpamMainPage.EpamSearchPage
{
    internal class EpamSearchPage : AbstractPage
    {
        public EpamSearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement linkCareers => driver.FindElement(By.LinkText("Careers"));
        public IReadOnlyCollection<IWebElement> foundLinks => driver.FindElements(By.XPath("//div[contains(@class, 'search-results__items')]/article[contains(@class, 'search-results__item')]//h3/a"));
    }
}
