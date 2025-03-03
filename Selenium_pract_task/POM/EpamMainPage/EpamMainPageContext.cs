﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamAboutPage;
using Selenium_pract_task.POM.EpamCareersPage;
using Selenium_pract_task.POM.EpamInsightsPage;
using Selenium_pract_task.POM.EpamSearchPage;

namespace Selenium_pract_task.POM.EpamMainPage
{
    public class EpamMainPageContext : AbstractPageContext
    {
        private EpamMainPage epamMainPage;

        public EpamMainPageContext(IWebDriver driver) : base(driver)
        {
            epamMainPage = new EpamMainPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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

        public EpamAboutPageContext ClickOnAboutLink()
        {
            epamMainPage.LinkAbout.Click();
            logger.Information("About link where clicked");
            return new EpamAboutPageContext(driver);
        }

        public EpamInsightsPageContext ClickOnLinkInsightsLink()
        {
            epamMainPage.LinkInsights.Click();
            logger.Information("Insights link where clicked.");
            return new EpamInsightsPageContext(driver);
        }

        public EpamMainPageContext ClickOnIconMagnifier()
        {
            var clickableElement = wait.Until(driver =>
            {
                var element = epamMainPage.IconMagnifier;
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            });
            epamMainPage.IconMagnifier.Click();
            logger.Information("Icon Magnifier where clicked.");
            return this;
        }

        public EpamMainPageContext SetTextInputSearchField(string value)
        {
            epamMainPage.InputSearchField.SendKeys(value);
            logger.Information($"Text [{value}] where send to InputSearchField.");
            return this;
        }

        public EpamSearchPageContext ClickButtonFind()
        {
            epamMainPage.ButtonFind.Click();
            logger.Information("Button Find where clicked.");
            return new EpamSearchPageContext(driver);
        }
    }
}
