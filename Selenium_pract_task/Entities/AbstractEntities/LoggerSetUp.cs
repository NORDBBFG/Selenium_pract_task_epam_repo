using NUnit.Framework;
using static Selenium_pract_task.Logger.Logger;

namespace Selenium_pract_task.Entities.AbstractEntities
{
    public abstract class LoggerSetUp
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            InitializeLogger();
            var logger = GetLogger();

            logger.Information("Global setup started.");
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            var logger = GetLogger();
            logger.Information("Global teardown completed.");
        }
    }
}
