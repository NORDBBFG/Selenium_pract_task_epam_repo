using NUnit.Framework;
using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.EpamArtificialIntelligencePage
{
    public class EpamArtificialIntelligencePageContext : AbstractPageContext
    {
        EpamArtificialIntelligencePage epamArtificialIntelligencePage;
        public EpamArtificialIntelligencePageContext(IWebDriver driver) : base(driver)
        {
            epamArtificialIntelligencePage = new EpamArtificialIntelligencePage(driver);
        }

        public string GetAiPageTitleText(string expectedAiType)
        {
            string titleText = epamArtificialIntelligencePage.AiPageTitle(expectedAiType).Text.ToLower();
            return titleText;
        }

        public bool VerifyOurRelatedExpertiseSectionExist(bool expectedResult = true)
        {
            var actualResult = epamArtificialIntelligencePage.OurRelatedExpertiseSection.Enabled && epamArtificialIntelligencePage.OurRelatedExpertiseSection.Displayed;

            return actualResult;
        }
    }
}
