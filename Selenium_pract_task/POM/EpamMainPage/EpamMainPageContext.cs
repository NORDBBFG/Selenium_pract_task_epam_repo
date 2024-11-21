using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage.EpamCareersPage;

namespace Selenium_pract_task.POM.EpamMainPage
{
    internal class EpamMainPageContext : AbstractPageContext
    {
        private EpamMainPage epamMainPage;
        private WebDriverWait wait;

        public EpamMainPageContext(IWebDriver driver)
        {
            this.driver = driver;
            epamMainPage = new EpamMainPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public EpamCareersPageContext clickOnCareersLink()
        {
            var clickableElement = wait.Until(driver =>
            {
                var element = epamMainPage.linkCareers;
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
            epamMainPage.linkCareers.Click();
            return new EpamCareersPageContext(driver);
        }
    }
}
