using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_pract_task.POM.EpamMainPage;
using Selenium_pract_task.POM.UIElements.EpamContinuumComponent;

namespace Selenium_pract_task.Entities.AbstractEntities
{
    public abstract class AbstractPageContext : AbstractPage
    {
        protected WebDriverWait wait;
        private EpamCookiesConsentComponent epamCookiesConsentComponent;

        protected AbstractPageContext(IWebDriver driver) : base(driver)
        {
            epamCookiesConsentComponent = new EpamCookiesConsentComponent(driver);
        }

        public T VerifyCookiesHandler<T>() where T : class
        {
            try
            {
                var element = wait.Until(driver =>
                {
                    try
                    {
                        var cookieButton = epamCookiesConsentComponent.ButtonAcceptAllCookies;

                        if (cookieButton != null && cookieButton.Displayed && cookieButton.Enabled)
                        {
                            cookieButton.Click();
                            return cookieButton;
                        }
                    }
                    catch (ElementClickInterceptedException)
                    {
                        return null;
                    }

                    return null;
                });

            }
            catch (WebDriverTimeoutException)
            {
                return Activator.CreateInstance(typeof(T), driver) as T;
            }

            return Activator.CreateInstance(typeof(T), driver) as T;
        }
    }
}
