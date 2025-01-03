using NUnit.Framework;
using Serilog;
using static Selenium_pract_task.Logger.Logger;

namespace Selenium_pract_task.Entities.AbstractEntities
{
    public abstract class LoggerSetUp
    {
        public ILogger logger;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            InitializeLogger();
            logger = GetLogger();

            logger.Information("Global setup started.");
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            logger.Information("Global teardown completed.");
        }
    }
}
