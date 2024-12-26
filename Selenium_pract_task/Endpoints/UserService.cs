using Newtonsoft.Json;
using RestSharp;
using Selenium_pract_task.Entities;
using Selenium_pract_task.Entities.BusinessModels;
using static Selenium_pract_task.Constants.Constants.IOConstants;
using static Selenium_pract_task.Logger.Logger;

namespace Selenium_pract_task.Endpoints
{
    public class UserService
    {
        private readonly BaseApiClient _client;
        private const string clientsEndpoint = $"{userApiEndpoint}/users";

        public UserService(string endpoint = clientsEndpoint)
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
            logger.Information($"Response received with status code: {response.StatusCode}");

            return response;
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
            logger.Information($"Response received with status code: {response.StatusCode}");

            return response;
        }

        public List<UserModel> DeserializeUsers(RestResponse response)
        {
            return JsonConvert.DeserializeObject<List<UserModel>>(response.Content);
        }

        public dynamic DeserializeUserCreationResponse(RestResponse response)
        {
            return JsonConvert.DeserializeObject<dynamic>(response.Content);
        }
    }
}
