﻿using NUnit.Framework;
using Selenium_pract_task.Endpoints;
using Selenium_pract_task.Entities.AbstractEntities;
using static Selenium_pract_task.Constants.Constants.IOConstants;
using static Selenium_pract_task.Logger.Logger;
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
            var logger = GetLogger();
            logger.Information("Starting ValidateContentTypeHeaderTest.");

            var response = _usersEndpoint.GetUsersResponse();

            var contentHeaders = response.ContentHeaders.FirstOrDefault(h => h.Name == "Content-Type")?.Value?.ToString(); ;

            Assert.That(contentHeaders, Is.Not.Null, "ContentType is null in the response.");

            Assert.That(contentHeaders, Does.Contain("application/json; charset=utf-8"),
                $"Content-Type does not contain 'application/json'. Actual: {contentHeaders}");

            logger.Information("ValidateContentTypeHeaderTest passed successfully.");
        }

        [Test]
        public void ValidateUserCreationTest()
        {
            var logger = GetLogger();
            logger.Information("Starting ValidateUserCreationTest.");

            var response = _usersEndpoint.CreateUser("John Doe", "johndoe");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created),
                "Expected status code 201.");

            var responseBody = _usersEndpoint.DeserializeUserCreationResponse(response);
            Assert.That(responseBody.id, Is.Not.Null,
                "Response does not contain ID field.");

            logger.Information("ValidateUserCreationTest passed successfully.");
        }

        [Test]
        public void ValidateUserNotifiedIfResourceNotExist()
        {
            var logger = GetLogger();
            logger.Information("Starting ValidateUserNotifiedIfResourceNotExist.");

            var invalidEndpoint = new UserService($"{userApiEndpoint}/invalidendpoint");
            var response = invalidEndpoint.GetUsersResponse();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
                "Expected status code 404.");

            logger.Information("ValidateUserNotifiedIfResourceNotExist passed successfully.");
        }

        [Test]
        public void ValidateUsersListTest()
        {
            var logger = GetLogger();
            logger.Information("Starting ValidateUsersListTest.");

            var response = _usersEndpoint.GetUsersResponse();
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
        public void ValidateUsersResponseBodyTest()
        {
            var logger = GetLogger();
            logger.Information("Starting ValidateUsersResponseBodyTest.");

            var response = _usersEndpoint.GetUsersResponse();
            var users = _usersEndpoint.DeserializeUsers(response);

            Assert.That(users.Count, Is.EqualTo(10), "Expected 10 users.");
            Assert.That(users.Select(u => u.Id).Distinct().Count(), Is.EqualTo(users.Count),
                "User IDs are not unique.");

            foreach (var user in users)
            {
                Assert.That(user.Name, Is.Not.Null, "User name is null.");
                Assert.That(user.Username, Is.Not.Null, "User username is null.");
                Assert.That(user.Company, Is.Not.Null, "User company is null.");
                Assert.That(user.Company.Name, Is.Not.Null, "User company name is null.");
            }

            logger.Information("ValidateUsersResponseBodyTest passed successfully.");
        }
    }
}