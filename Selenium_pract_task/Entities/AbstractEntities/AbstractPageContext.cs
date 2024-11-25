using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium_pract_task.Entities.AbstractEntities
{
    public abstract class AbstractPageContext : AbstractPage
    {
        public T VerifyPageTitle<T>(string expectedTitle) where T : class
        {
            string actualTitle = driver.Title;
            Assert.That(actualTitle, Is.EqualTo(expectedTitle));
            try
            {
                return Activator.CreateInstance(typeof(T), driver) as T;
            }
            catch (Exception ex)
            {
                throw new Exception($"Something hepend with returning class! \n Exeption: {ex}");
            }
        }

        public T ScrolePage<T>(int expectedTimes) where T : class
        {
            IWebElement body = driver.FindElement(By.TagName("body"));
            for (int i = 0; i < expectedTimes; i++)
            {
                body.SendKeys(Keys.ArrowDown);
                Thread.Sleep(100);
            }
            try
            {
                return Activator.CreateInstance(typeof(T), driver) as T;
            }
            catch (Exception ex)
            {
                throw new Exception($"Something hepend with returning class! \n Exeption: {ex}");
            }
        }

        public T ClosePageByHandle<T>(string pageHandle) where T : class
        {
            driver.SwitchTo().Window(pageHandle);
            driver.Close();
            try
            {
                return Activator.CreateInstance(typeof(T), driver) as T;
            }
            catch (Exception ex)
            {
                throw new Exception($"Something hepend with returning class! \n Exeption: {ex}");
            }
        }

        public T SwitchPagebyHandle<T>(string pageHandle) where T : class
        {
            driver.SwitchTo().Window(pageHandle);
            try
            {
                return Activator.CreateInstance(typeof(T), driver) as T;
            }
            catch (Exception ex)
            {
                throw new Exception($"Something hepend with returning class! \n Exeption: {ex}");
            }
        }
    }
}
