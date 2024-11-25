using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage.EpamJobPage;

namespace Selenium_pract_task.POM.EpamMainPage.EpamCareersPage
{
    public class EpamCareersPageContext : AbstractPageContext
    {
        private EpamCareersPage epamCereersPage;
        private WebDriverWait wait;

        public EpamCareersPageContext(IWebDriver driver)
        {
            this.driver = driver;
            epamCereersPage = new EpamCareersPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public EpamCareersPageContext FillInputKeyword(string keyword)
        {
            epamCereersPage.InputKeyword.SendKeys(keyword);
            return this;
        }

        public EpamCareersPageContext ClickInputLocation()
        {
            epamCereersPage.InputLocation.Click();
            return this;
        }

        public EpamCareersPageContext SelectInputLocationAllLocations()
        {
            epamCereersPage.InputLocationMenuItemnAllLocations.Click();
            return this;
        }

        public EpamCareersPageContext CheckRemoutCheckBox()
        {
            epamCereersPage.CheckBoxRemote.Click();
            return this;
        }

        public EpamCareersPageContext ClickButtonFind()
        {
            epamCereersPage.ButtonFind.Click();
            return this;
        }

        public EpamJobPageContext ClickButtonViewAndApplyLastElement()
        {
            epamCereersPage.ButtonViewAndApplyLastElement.Click();
            return new EpamJobPageContext(driver);
        }
    }
}
