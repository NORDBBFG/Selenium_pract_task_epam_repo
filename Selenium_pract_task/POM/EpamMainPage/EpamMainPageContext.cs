using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage.EpamCareersPage;
using Selenium_pract_task.POM.EpamMainPage.EpamSearchPage;

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

        public EpamMainPageContext VerifyCookiesHendler()
        {
            var element = epamMainPage.ButtonAcceptAllCookies;
            var cond = element.Enabled;
            if (cond)
            {
                element.Click();
                return this;
            }
            return this;
        }

        public EpamCareersPageContext ClickOnCareersLink()
        {
            var clickableElement = wait.Until(driver =>
            {
                var element = epamMainPage.LinkCareers;
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
            epamMainPage.LinkCareers.Click();
            return new EpamCareersPageContext(driver);
        }

        public EpamMainPageContext ClickOnIconMagnifier()
        {
            var clickableElement = wait.Until(driver =>
            {
                var element = epamMainPage.IconMagnifier;
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
            epamMainPage.IconMagnifier.Click();
            return this;
        }

        public EpamMainPageContext SetTextInputSearchField(string value)
        {
            epamMainPage.InputSearchField.SendKeys(value);
            return this;
        }

        public EpamSearchPageContext ClickButtonFind()
        {
            epamMainPage.ButtonFind.Click();
            return new EpamSearchPageContext(driver);
        }
    }
}
