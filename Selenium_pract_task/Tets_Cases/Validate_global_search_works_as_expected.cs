﻿using NUnit.Framework;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.POM.EpamMainPage;

namespace Selenium_pract_task.Tets_Cases
{
    [TestFixture]
    [Category("UI")]
    public class Validate_global_search_works_as_expected : BaseTest
    {
        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]
        public void TestGlobalSearchFunctionality(string searchFieldValue)
        {
            var epamMainPageContext = new EpamMainPageContext(driver);
            epamMainPageContext.VerifyCookiesHandler<EpamMainPageContext>()
                .ClickOnIconMagnifier()
                .SetTextInputSearchField(searchFieldValue)
                .ClickButtonFind()
                .VerifyAllSerchedLinksContainsSerchedText(searchFieldValue);
        }
    }
}
