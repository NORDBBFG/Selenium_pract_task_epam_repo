using OpenQA.Selenium;

namespace Selenium_pract_task.Entities.AbstractEntities
{
    public abstract class AbstractPageContext : AbstractPage
    {
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
    }
}
