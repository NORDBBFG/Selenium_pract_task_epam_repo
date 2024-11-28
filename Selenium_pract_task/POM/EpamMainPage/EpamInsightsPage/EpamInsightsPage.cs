﻿using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.EpamMainPage.EpamInsightsPage
{
    public class EpamInsightsPage : AbstractPage
    {
        public EpamInsightsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ButtonNextContinuumSlider => driver.FindElement(By.XPath("(//button[@role='presentation' and @class='slider__right-arrow slider-navigation-arrow'])[1]"));
        public IWebElement ActiveTextContinuumSlider => driver.FindElement(By.XPath("(//div[@aria-hidden='false']//p)[1]"));
        public IWebElement ButtonReadMoreContinuumSlider => driver.FindElement(By.XPath("(//div[@aria-hidden='false']//a)[1]"));
    }
}
