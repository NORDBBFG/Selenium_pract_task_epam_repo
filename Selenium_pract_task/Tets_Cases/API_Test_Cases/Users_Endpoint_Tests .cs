using NUnit.Framework;
using Selenium_pract_task.Endpoints;
using Selenium_pract_task.Entities.AbstractEntities;
using static Selenium_pract_task.Constants.Constants.IOConstants;
using System.Net;

namespace Selenium_pract_task.Tets_Cases.API_Test_Cases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("API")]
    public class Users_Service_Tests : BaseApiTest
    {
        private UserService _usersEndpoint;

        [SetUp]
        public void Setup()
        {
            _usersEndpoint = new UserService();
        }

        [Test]
        public void ValidateContentTypeHeaderTest()
        {
            logger.Information("Starting ValidateContentTypeHeaderTest.");

            var response = _usersEndpoint.GetUsersResponse();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Expected status code 200 but was: [{response.StatusCode}]");

            var contentHeaders = response.ContentHeaders.FirstOrDefault(h => h.Name == "Content-Type")?.Value?.ToString(); ;

            Assert.That(contentHeaders, Is.Not.Null, "ContentType is null in the response.");

            Assert.That(contentHeaders, Does.Contain("application/json; charset=utf-8"),
                $"Content-Type does not contain 'application/json'. Actual: {contentHeaders}");

            logger.Information("ValidateContentTypeHeaderTest passed successfully.");
        }

        [TestCase("John Doe", "johndoe")]
        public void ValidateUserCreationTest(string name, string username)
        {
            logger.Information("Starting ValidateUserCreationTest.");

            var response = _usersEndpoint.CreateUser(name, username);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created),
                "Expected status code 201.");

            var responseBody = _usersEndpoint.DeserializeUserCreationResponse(response);
            var createdUser = responseBody.id.ToString();

            Assert.That(string.IsNullOrEmpty(createdUser), Is.False,
                "Response does not contain ID field.");

            logger.Information("ValidateUserCreationTest passed successfully.");
        }

        [Test]
        public void ValidateUserNotifiedIfResourceNotExist()
        {
            logger.Information("Starting ValidateUserNotifiedIfResourceNotExist.");

            var invalidEndpoint = new UserService($"{userApiEndpoint}/invalidendpoint");
            var response = invalidEndpoint.GetUsersResponse();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
                "Expected status code 404.");

            logger.Information("ValidateUserNotifiedIfResourceNotExist passed successfully.");
        }

        [Test]
        public void ValidateUsersResponseBodyTest()
        {
            logger.Information("Starting ValidateUsersListTest.");

            var response = _usersEndpoint.GetUsersResponse();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Expected status code 200 but was: [{response.StatusCode}]");

            var users = _usersEndpoint.DeserializeUsers(response);

            Assert.That(users, Is.Not.Null, "Users list is null.");
            Assert.That(users.Count, Is.EqualTo(10), "Expected 10 users in the response.");

            foreach (var user in users)
            {
                Assert.That(user.Name, Is.Not.Null, "User name is null.");
                Assert.That(user.Username, Is.Not.Null, "User username is null.");
                Assert.That(user.Company, Is.Not.Null, "User company is null.");
            }

            logger.Information("ValidateUsersListTest passed successfully.");
        }

        [Test]
        public void ValidateUsersListTest()
        {
            logger.Information("Starting ValidateUsersResponseBodyTest.");

            var response = _usersEndpoint.GetUsersResponse();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Expected status code 200 but was: [{response.StatusCode}]");

            var users = _usersEndpoint.DeserializeUsers(response);

            foreach (var user in users)
            {
                Assert.That(user.Id, Is.Not.Null, "User Id is null.");
                Assert.That(user.Name, Is.Not.Null, "User name is null.");
                Assert.That(user.Username, Is.Not.Null, "User username is null.");
                Assert.That(user.Email, Is.Not.Null, "User email is null.");
                Assert.That(user.Address, Is.Not.Null, "User address is null.");
                Assert.That(user.Phone, Is.Not.Null, "User phone is null.");
                Assert.That(user.Website, Is.Not.Null, "User website is null.");
                Assert.That(user.Company, Is.Not.Null, "User company is null.");
            }

            logger.Information("ValidateUsersResponseBodyTest passed successfully.");
        }
    }
}
