using RestSharp;

namespace Selenium_pract_task.Entities
{
    public class RequestBuilder
    {
        private readonly RestRequest _request;

        private RequestBuilder(string resource, Method method)
        {
            _request = new RestRequest(resource, method);
        }

        public static RequestBuilder Create(string resource, Method method)
        {
            return new RequestBuilder(resource, method);
        }

        public RequestBuilder AddHeader(string name, string value)
        {
            _request.AddHeader(name, value);
            return this;
        }

        public RestRequest Build()
        {
            return _request;
        }
    }
}
