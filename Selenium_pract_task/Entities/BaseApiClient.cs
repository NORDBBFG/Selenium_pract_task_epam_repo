using RestSharp;

namespace Selenium_pract_task.Entities
{
    public class BaseApiClient
    {
        private readonly RestClient _client;

        public BaseApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public RestResponse SendRequest(RestRequest request)
        {
            var response = _client.Execute(request);
            return response;
        }
    }
}
