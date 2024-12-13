using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;

namespace Selenium_pract_task.POM.EpamSearchPage
{
    public class EpamSearchPageContext : AbstractPageContext
    {
        private EpamSearchPage epamSearchPage;

        public EpamSearchPageContext(IWebDriver driver) : base(driver)
        {
            epamSearchPage = new EpamSearchPage(driver);
        }

        public List<string> GetAllSerchedLinksText()
        {
           var list = epamSearchPage.FoundLinks
        .Select(link => link.Text.ToLower())
        .ToList();

            return list;
        }
    }
}
