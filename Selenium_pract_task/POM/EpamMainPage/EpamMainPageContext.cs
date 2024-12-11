using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Selenium_pract_task.Entities.AbstractEntities;

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

        public EpamMainPageContext ClickOnLinkServices()
        {
            epamMainPage.epamHedderLinksComponent.LinkServices.Click();
            logger.Information("Services link where clicked.");
            return this;
        }

        public EpamMainPageContext ClickOnLinkServicesAiType(string aiType)
        {
            var actions = new Actions(driver);
            actions.MoveToElement(epamMainPage.epamHedderLinksComponent.LinkServices).Perform();
            Thread.Sleep(1000);

            epamMainPage.epamHedderLinksComponent.LinkServicesAiType(aiType).Click();
            logger.Information($"Services link [{aiType}] where clicked.");
            return this;
        }
    }
}
