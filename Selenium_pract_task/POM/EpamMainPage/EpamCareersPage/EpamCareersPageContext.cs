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

        public EpamCareersPageContext fillInputKeyword(string keyword)
        {
            epamCereersPage.inputKeyword.SendKeys(keyword);
            return this;
        }

        public EpamCareersPageContext clickInputLocation()
        {
            epamCereersPage.inputLocation.Click();
            return this;
        }

        public EpamCareersPageContext selectInputLocationAllLocations()
        {
            epamCereersPage.inputLocationMenuItemnAllLocations.Click();
            return this;
        }

        public EpamCareersPageContext checkRemoutCheckBox()
        {
            epamCereersPage.checkBoxRemote.Click();
            return this;
        }

        public EpamCareersPageContext clickButtonFind()
        {
            epamCereersPage.buttonFind.Click();
            return this;
        }

        public EpamJobPageContext clickButtonViewAndApplyLastElement()
        {
            epamCereersPage.buttonViewAndApplyLastElement.Click();
            return new EpamJobPageContext(driver);
        }
    }
}
