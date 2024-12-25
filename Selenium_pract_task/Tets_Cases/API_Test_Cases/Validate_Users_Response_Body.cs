using Newtonsoft.Json;
using NUnit.Framework;
using Selenium_pract_task.Endpoints;
using Selenium_pract_task.Entities.AbstractEntities;
using Selenium_pract_task.Entities.BusinessModels;
using static Selenium_pract_task.Logger.Logger;

namespace Selenium_pract_task.Tets_Cases.API_Test_Cases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("API")]
    public class Validate_Users_Response_Body : BaseApiTest
    {
        private UsersEndpoint _usersEndpoint = new UsersEndpoint();

        [Test]
        public void ValidateUsersResponseBody()
        {
            var logger = GetLogger();
            logger.Information("Starting ValidateUsersResponseBodyTest.");

            var response = _usersEndpoint.GetUsersResponse();
            var users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content);
            _usersEndpoint.ValidateUsersResponseBody(users);

            logger.Information("ValidateUsersResponseBodyTest passed successfully.");
        }
    }
}
