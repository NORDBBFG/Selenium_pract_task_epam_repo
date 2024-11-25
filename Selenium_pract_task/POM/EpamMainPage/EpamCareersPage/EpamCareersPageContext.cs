using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using Selenium_pract_task.POM.EpamMainPage.EpamJobPage;

namespace Selenium_pract_task.POM.EpamMainPage.EpamCareersPage
{
    internal class EpamCareersPageContext : AbstractPageContext
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
