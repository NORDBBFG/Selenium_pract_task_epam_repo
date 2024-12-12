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

        public EpamArtificialIntelligencePageContext VerifyAiPageTitleContainsExpectedAiType(string expectedAiType, bool expectedResult = true)
        {
            string titleText = epamArtificialIntelligencePage.AiPageTitle(expectedAiType).Text.ToLower();
            var actualResult = titleText.Contains(expectedAiType.ToLower());
            Assert.That(expectedResult, Is.EqualTo(actualResult), $"AiPage title: [{titleText}], do not contains expected value: [{expectedAiType}].");

            return this;
        }

        public EpamArtificialIntelligencePageContext VerifyOurRelatedExpertiseSectionExist(bool expectedResult = true)
        {
            var actualResult = epamArtificialIntelligencePage.OurRelatedExpertiseSection.Enabled && epamArtificialIntelligencePage.OurRelatedExpertiseSection.Displayed;
            Assert.That(expectedResult, Is.EqualTo(actualResult), $"Our Related Expertise Section is not displayed on the page");

            return this;
        }
    }
}
