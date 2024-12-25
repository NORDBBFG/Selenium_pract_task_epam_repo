using NUnit.Framework;
using Selenium_pract_task.Endpoints;
using Selenium_pract_task.Entities.AbstractEntities;
using static Selenium_pract_task.Constants.Constants.IOConstants;
using static Selenium_pract_task.Logger.Logger;

namespace Selenium_pract_task.Tets_Cases.API_Test_Cases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("API")]
    public class Validate_User_Notified_If_Resource_Not_Exist : BaseApiTest
    {
        private const string invalidEndpoint = $"{userApiEndpoint}/invalidendpoint";
        private UsersEndpoint _usersEndpoint = new UsersEndpoint(invalidEndpoint);
        private string expectedStatusCode = "404";

        [Test]
        public void ValidateUserNotifiedIfResourceNotExist()
        {
            var logger = GetLogger();
            logger.Information("Starting ValidateUserNotifiedIfResourceNotExist.");

            _usersEndpoint.ValidateResponsCodeStatus(expectedStatusCode);

            logger.Information("ValidateUserNotifiedIfResourceNotExist passed successfully.");
        }
    }
}
