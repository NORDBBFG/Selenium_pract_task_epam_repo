using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_pract_task.POM.EpamMainPage.EpamJobPage
{
    internal class EpamJobPage : AbstractPage
    {
        public EpamJobPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement jobeTitle => driver.FindElement(By.XPath("//h1[@class='vacancy-details-23__job-title']"));
    }
}
