﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using NUnit.Framework;

namespace Selenium_pract_task.POM.EpamMainPage.EpamJobPage
{
    public class EpamJobPageContext : AbstractPageContext
    {
        private EpamJobPage epamJobPage;

        public EpamJobPageContext(IWebDriver driver)
        {
            this.driver = driver;
            epamJobPage = new EpamJobPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public EpamJobPageContext VerifyJobTitleContainsPrograminLanguage(string value,bool expectedResult = true)
        {
            string titleText = epamJobPage.JobeTitle.Text.ToLower();
            var actualResult = titleText.Contains(value.ToLower());
            Assert.That(expectedResult, Is.EqualTo(actualResult), $"Job title: [{titleText}], do not contains expected value: [{value}].");

            return this;
        }
    }
}
