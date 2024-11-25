using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium_pract_task.POM.EpamMainPage.EpamCareersPage;
using NUnit.Framework;

namespace Selenium_pract_task.POM.EpamMainPage.EpamJobPage
{
    internal class EpamJobPageContext : AbstractPageContext
    {
        private EpamJobPage epamJobPage;
        private WebDriverWait wait;

        public EpamJobPageContext(IWebDriver driver)
        {
            this.driver = driver;
            epamJobPage = new EpamJobPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public EpamJobPageContext VerifyJobTitleContainsValue(string value,bool expectedResult = true)
        {
            string titleText = epamJobPage.JobeTitle.Text;
            var actualResult = titleText.Contains(value);
            Assert.That(expectedResult, Is.EqualTo(actualResult), $"Job title: [{titleText}], do not contains expected value: [{value}].");

            return this;
        }
    }
}
