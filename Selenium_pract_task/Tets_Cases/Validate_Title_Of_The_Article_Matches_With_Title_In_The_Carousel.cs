using NUnit.Framework;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage;

namespace Selenium_pract_task.Tets_Cases
{
    [TestFixture]
    [Category("UI")]
    public class Validate_Title_Of_The_Article_Matches_With_Title_In_The_Carousel : BaseTest
    {
        private string activeSliderText;

        [Test]
        public void ValidateArticleMaches()
        {
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.VerifyCookiesHandler<EpamMainPageContext>()
                .ClickOnLinkInsightsLink()
                .ClickButtonNextSlideContinuum(2)
                .GetTextActiveSliderContinuum(out activeSliderText)
                .ClickButtonReadMoreContinuum()
                .VerifyCountinuumPageTitle(activeSliderText);
        }
    }
}
