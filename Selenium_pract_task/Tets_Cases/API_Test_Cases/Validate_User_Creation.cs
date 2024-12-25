using NUnit.Framework;
using Selenium_pract_task.Endpoints;
using Selenium_pract_task.Entities.AbstractEntities;
using static Selenium_pract_task.Logger.Logger;

namespace Selenium_pract_task.Tets_Cases.API_Test_Cases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("API")]
    public class Validate_User_Creation : BaseApiTest
    {
        private UsersEndpoint _usersEndpoint = new UsersEndpoint();

        [Test]
        public void ValidateUserCreation()
        {
            var logger = GetLogger();
            logger.Information("Starting ValidateUserCreationTest.");

            var response = _usersEndpoint.CreateUser("John Doe", "johndoe");
            _usersEndpoint.ValidateUserCreationResponse(response);

            logger.Information("ValidateUserCreationTest passed successfully.");
        }
    }
}
