using Newtonsoft.Json;
using RestSharp;
using Selenium_pract_task.Entities;
using Selenium_pract_task.Entities.BusinessModels;
using System.Net;
using static Selenium_pract_task.Constants.Constants.IOConstants;
using static Selenium_pract_task.Logger.Logger;

namespace Selenium_pract_task.Endpoints
{
    public class UsersEndpoint
    {
        private readonly BaseApiClient _client;
        private const string clientsEndpoint = $"{userApiEndpoint}/users";

        public UsersEndpoint(string endpoint = clientsEndpoint)
        {
            _client = new BaseApiClient(endpoint);
        }

        public RestResponse GetUsersResponse()
        {
            var logger = GetLogger();
            logger.Information("Sending GET request to fetch users.");

            var request = RequestBuilder
                .Create(string.Empty, Method.Get)
                .Build();

            var response = _client.SendRequest(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                logger.Error($"Expected status code 200, but got {response.StatusCode}");
                throw new HttpRequestException($"Failed to fetch users. Status: {response.StatusCode}");
            }

            logger.Information($"Response received with status code: {response.StatusCode}");
            return response;
        }

        public void ValidateResponsCodeStatus(string expectedStatusCode)
        {
            var logger = GetLogger();
            logger.Information("Sending GET request to validate response status code.");

            var request = RequestBuilder
                .Create(string.Empty, Method.Get)
                .Build();

            var response = _client.SendRequest(request);

            var actualStatusCode = ((int)response.StatusCode).ToString();

            if (actualStatusCode != expectedStatusCode)
            {
                logger.Error($"Expected status code {expectedStatusCode}, but got {actualStatusCode}.");
                throw new Exception($"Invalid response code: expected {expectedStatusCode}, but got {actualStatusCode}.");
            }

            logger.Information($"Response code validated successfully as {expectedStatusCode}.");
        }

        public void ValidateUsersList(RestResponse response)
        {
            var logger = GetLogger();
            logger.Information("Validating users list.");

            var users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content);

            if (users == null || !users.Any())
            {
                logger.Error("User list is empty or null.");
                throw new Exception("User list is empty or null.");
            }

            foreach (var user in users)
            {
                if (user.Id <= 0)
                    throw new Exception($"Invalid user ID: {user.Id}");
                if (string.IsNullOrEmpty(user.Name))
                    throw new Exception("User name is empty.");
                if (string.IsNullOrEmpty(user.Username))
                    throw new Exception("User username is empty.");
                if (user.Company == null || string.IsNullOrEmpty(user.Company.Name))
                    throw new Exception("User company name is empty or null.");
            }

            logger.Information("Users list validation passed.");
        }

        public RestResponse CreateUser(string name, string username)
        {
            var logger = GetLogger();
            logger.Information("Sending POST request to create a user.");

            var request = RequestBuilder
                .Create(string.Empty, Method.Post)
                .AddHeader("Content-Type", "application/json")
                .Build();
            request.AddJsonBody(new { name, username });

            var response = _client.SendRequest(request);

            if (response.StatusCode != HttpStatusCode.Created)
            {
                logger.Error($"Expected status code 201, but got {response.StatusCode}");
                throw new HttpRequestException($"Failed to create user. Status: {response.StatusCode}");
            }

            logger.Information($"Response received with status code: {response.StatusCode}");
            return response;
        }

        public void ValidateContentTypeHeader(RestResponse response)
        {
            var logger = GetLogger();
            logger.Information("Validating Content-Type header.");

            var actualContentType = response.ContentType;

            if (string.IsNullOrEmpty(actualContentType))
                throw new Exception("Content-Type header is missing.");
            if (actualContentType != "application/json; charset=utf-8")
                throw new Exception($"Invalid Content-Type header value: [{actualContentType}]");

            logger.Information("Content-Type header validated successfully.");
        }

        public void ValidateUsersResponseBody(List<UserModel> users)
        {
            var logger = GetLogger();
            logger.Information("Validating users response body.");

            if (users == null || users.Count != 10)
                throw new Exception("Response does not contain 10 users.");

            var uniqueIds = users.Select(u => u.Id).Distinct().ToList();
            if (uniqueIds.Count != 10)
                throw new Exception("User IDs are not unique.");

            foreach (var user in users)
            {
                if (string.IsNullOrEmpty(user.Name))
                    throw new Exception("User name is empty.");
                if (string.IsNullOrEmpty(user.Username))
                    throw new Exception("User username is empty.");
                if (user.Company == null || string.IsNullOrEmpty(user.Company.Name))
                    throw new Exception("User company name is empty or null.");
            }

            logger.Information("Users response body validated successfully.");
        }

        public void ValidateUserCreationResponse(RestResponse response)
        {
            var logger = GetLogger();
            logger.Information("Validating user creation response.");

            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception($"Expected 201 Created, but got {response.StatusCode}.");

            var responseBody = JsonConvert.DeserializeObject<dynamic>(response.Content);
            if (responseBody.id == null)
                throw new Exception("Response does not contain ID field.");

            logger.Information("User creation response validated successfully.");
        }
    }
}
