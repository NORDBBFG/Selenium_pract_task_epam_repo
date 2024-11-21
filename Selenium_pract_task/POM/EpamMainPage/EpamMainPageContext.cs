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

        public EpamMainPageContext verifyCookiesHendler()
        {
            var element = epamMainPage.buttonAcceptAllCookies;
            var cond = element.Enabled;
            if (cond)
            {
                element.Click();
                return this;
            }
            return this;
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

        public EpamMainPageContext clickOnIconMagnifier()
        {
            var clickableElement = wait.Until(driver =>
            {
                var element = epamMainPage.iconMagnifier;
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
            epamMainPage.iconMagnifier.Click();
            return this;
        }

        public EpamMainPageContext setTextInputSearchField(string value)
        {
            epamMainPage.inputSearchField.SendKeys(value);
            return this;
        }

        public EpamSearchPageContext clickButtonFind()
        {
            epamMainPage.buttonFind.Click();
            return new EpamSearchPageContext(driver);
        }
    }
}
