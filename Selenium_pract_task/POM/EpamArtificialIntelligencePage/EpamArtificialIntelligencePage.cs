using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.UIElements.EpamHedderLinksComponent;

namespace Selenium_pract_task.POM.EpamArtificialIntelligencePage
{
    public class EpamArtificialIntelligencePage : AbstractPage
    {
        public EpamHedderLinksComponent epamHedderLinksComponent;
        public EpamArtificialIntelligencePage(IWebDriver driver) : base(driver)
        {
            epamHedderLinksComponent = new EpamHedderLinksComponent(driver);
        }
        
        public IWebElement AiPageTitle(string aiTypeTitle) => driver.FindElement(By.XPath($"//span[contains(text(), '{aiTypeTitle}') and @class='museo-sans-500 gradient-text']"));
        public IWebElement OurRelatedExpertiseSection=> driver.FindElement(By.XPath("//div//div//div//p//span[contains(text(), 'Our Related Expertise')]"));
    }
}
