using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.EpamMainPage
{
    public class EpamMainPage : AbstractPage
    {
        public EpamMainPage(IWebDriver driver) : base(driver)
        {
        }
        
        public IWebElement LinkCareers => driver.FindElement(By.LinkText("Careers"));
        public IWebElement LinkAbout => driver.FindElement(By.LinkText("About"));
        public IWebElement LinkInsights => driver.FindElement(By.LinkText("Insights"));
        public IWebElement ButtonAcceptAllCookies => driver.FindElement(By.XPath("//button[@id='onetrust-accept-btn-handler']"));
        public IWebElement IconMagnifier => driver.FindElement(By.XPath("//button[@class='header-search__button header__icon']"));
        public IWebElement InputSearchField => driver.FindElement(By.Id("new_form_search"));
        public IWebElement ButtonFind => driver.FindElement(By.XPath("//button[descendant::span[normalize-space(text())='Find']]"));
    }
}
