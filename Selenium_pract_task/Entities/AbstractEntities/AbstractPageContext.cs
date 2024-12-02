using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium_pract_task.Entities.AbstractEntities
{
    public abstract class AbstractPageContext : AbstractPage
    {
        protected WebDriverWait wait;

        protected AbstractPageContext(IWebDriver driver) : base(driver)
        {
        }
    }
}
