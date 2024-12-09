using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.EpamSearchPage
{
    public class EpamSearchPage : AbstractPage
    {
        public EpamSearchPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement LinkCareers => driver.FindElement(By.LinkText("Careers"));
        public IReadOnlyCollection<IWebElement> FoundLinks => driver.FindElements(By.XPath("//article//h3/a"));
    }
}
