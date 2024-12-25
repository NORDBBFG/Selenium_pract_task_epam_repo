using NUnit.Framework;
using static Selenium_pract_task.Logger.Logger;

namespace Selenium_pract_task.Entities.AbstractEntities
{
    public abstract class BaseApiTest : LoggerSetUp
    {
        [SetUp]
        public void SetUp()
        {
            var logger = GetLogger();
            logger.Information("Api test setup started.");
        }

        [TearDown]
        public void TearDown()
        {
            var logger = GetLogger();
            logger.Information("Api test teardown completed.");
        }
    }
}
