using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using static Selenium_pract_task.Constants.Constants.IOConstants;
using static Selenium_pract_task.FileHelper.FileHelper;
using NUnit.Framework;

namespace Selenium_pract_task.POM.EpamAboutPage
{
    public class EpamAboutPageContext : AbstractPageContext
    {
        private EpamAboutPage epamAboutPage;

        public EpamAboutPageContext(IWebDriver driver) : base(driver)
        {
            epamAboutPage = new EpamAboutPage(driver);
        }

        public EpamAboutPageContext ClickButtonDownload()
        {
            epamAboutPage.ButtonDownload.Click();
            logger.Information("Button Download where clicked.");
            return this;
        }
    }
}
