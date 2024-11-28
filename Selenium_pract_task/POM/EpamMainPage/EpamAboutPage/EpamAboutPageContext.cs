﻿using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using static Selenium_pract_task.Constants.Constants.IOConstants;
using static Selenium_pract_task.FileHelper.FileHelper;
using NUnit.Framework;

namespace Selenium_pract_task.POM.EpamMainPage.EpamAboutPage
{
    public class EpamAboutPageContext : AbstractPageContext
    {
        EpamAboutPage epamAboutPage;

        private EpamMainPage epamMainPage;

        public EpamAboutPageContext(IWebDriver driver)
        {
            this.driver = driver;
            epamAboutPage = new EpamAboutPage(driver);
        }

        public EpamAboutPageContext ClickButtonDownload()
        {
            epamAboutPage.ButtonDownload.Click();
            return this;
        }

        public EpamAboutPageContext VerifyEPAMCompanyOverviewDownloadedFileExist(string fileName, int waitTimeSeconds = 10, bool expectedResolt = true)
        {
            string filePath = Path.Combine(windowsDefaultDownloadDirectoryPath, fileName);
            var actualResult = WaitForFileExist(filePath, waitTimeSeconds);
            Assert.That(expectedResolt, Is.EqualTo(actualResult), $"File [{fileName}] using file path: [{filePath}] was not found.");
            return this;
        }
    }
}
