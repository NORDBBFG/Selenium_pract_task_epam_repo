using OpenQA.Selenium;
using Selenium_pract_task.Entities.AbstractEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_pract_task.POM.EpamMainPage
{
    internal class EpamMainPage : AbstractPage
    {
        public EpamMainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement linkCareers => driver.FindElement(By.LinkText("Careers"));
    }
}
