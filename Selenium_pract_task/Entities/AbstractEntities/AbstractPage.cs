using OpenQA.Selenium;

namespace Selenium_pract_task.Entities.AbstractEntities
{
        public abstract class AbstractPage
        {
            protected IWebDriver driver;

        protected AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }

}