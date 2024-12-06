using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.EpamCareersPage
{
    public class EpamCareersPage : AbstractPage
    {
        public EpamCareersPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement InputKeyword => driver.FindElement(By.CssSelector("#new_form_job_search-keyword"));
        public IWebElement InputLocation => driver.FindElement(By.CssSelector(".recruiting-search__location"));
        public IWebElement InputLocationMenuItemnAllLocations => driver.FindElement(By.XPath("//li[@title='All Locations']"));
        public IWebElement CheckBoxRemote => driver.FindElement(By.XPath("//label[contains(@class, 'filter-label')][normalize-space()='Remote']"));
        public IWebElement ButtonFind => driver.FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement ButtonViewAndApplyLastElement => driver.FindElement(By.XPath("//ul[contains(@class, 'search-result__list')]//a[normalize-space()='View and apply'][last()]"));

    }
}
