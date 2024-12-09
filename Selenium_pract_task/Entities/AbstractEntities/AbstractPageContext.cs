using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_pract_task.POM.UIElements.EpamContinuumComponent;
using static Selenium_pract_task.Logger.Logger;
using Serilog;

namespace Selenium_pract_task.Entities.AbstractEntities
{
    public abstract class AbstractPageContext : AbstractPage
    {
        protected WebDriverWait wait;
        private EpamCookiesConsentComponent epamCookiesConsentComponent;
        protected ILogger logger;


        protected AbstractPageContext(IWebDriver driver) : base(driver)
        {
            epamCookiesConsentComponent = new EpamCookiesConsentComponent(driver);
            logger = GetLogger();
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
                logger.Information("Cookies Consent Component not appeared.");
                return Activator.CreateInstance(typeof(T), driver) as T;
            }

            logger.Information("Cookies Consent Component Verifide.");
            return Activator.CreateInstance(typeof(T), driver) as T;
        }
    }
}
