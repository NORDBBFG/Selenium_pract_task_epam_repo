using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamJobPage;

namespace Selenium_pract_task.POM.EpamCareersPage
{
    public class EpamCareersPageContext : AbstractPageContext
    {
        private EpamCareersPage epamCereersPage;

        public EpamCareersPageContext(IWebDriver driver) : base(driver)
        {
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

        public EpamCareersPageContext ScrollToCheckBoxRemote()
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", epamCereersPage.CheckBoxRemote);
                return this;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to scroll to the checkbox 'Remote'. \nException: {ex.Message}");
            }
        }
    }
}
