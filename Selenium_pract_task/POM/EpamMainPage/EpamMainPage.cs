using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_pract_task.POM.EpamMainPage
{
    internal class EpamMainPage : AbstractPage
    {
        public EpamMainPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        public IWebElement linkCareers => driver.FindElement(By.LinkText("Careers"));
        public IWebElement buttonAcceptAllCookies => driver.FindElement(By.XPath("//button[@id='onetrust-accept-btn-handler']"));
        public IWebElement iconMagnifier => driver.FindElement(By.XPath("//button[@class='header-search__button header__icon']"));
        public IWebElement inputSearchField => driver.FindElement(By.Id("new_form_search"));
        public IWebElement buttonFind => driver.FindElement(By.XPath("//button[descendant::span[normalize-space(text())='Find']]"));
    }
}
