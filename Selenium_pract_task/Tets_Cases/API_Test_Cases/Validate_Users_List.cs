using NUnit.Framework;
using Selenium_pract_task.Endpoints;
using Selenium_pract_task.Entities.AbstractEntities;
using static Selenium_pract_task.Logger.Logger;

namespace Selenium_pract_task.Tets_Cases.API_Test_Cases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("API")]
    public class Validate_Users_List : BaseApiTest
    {
        private UsersEndpoint _usersEndpoint = new UsersEndpoint();

        [Test]
        public void ValidateUsersList()
        {
            var logger = GetLogger();
            logger.Information("Starting ValidateUsersListTest.");

            var users = _usersEndpoint.GetUsersResponse();
            _usersEndpoint.ValidateUsersList(users);

            logger.Information("ValidateUsersListTest passed successfully.");
        }
    }
}
