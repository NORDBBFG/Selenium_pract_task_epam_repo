using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.EpamMainPage.EpamSearchPage
{
    public class EpamSearchPage : AbstractPage
    {
        public EpamSearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement LinkCareers => driver.FindElement(By.LinkText("Careers"));
        public IReadOnlyCollection<IWebElement> FoundLinks => driver.FindElements(By.XPath("//div[contains(@class, 'search-results__items')]/article[contains(@class, 'search-results__item')]//h3/a"));
    }
}
