using Newtonsoft.Json;
using RestSharp;

namespace RestAPI
{
    public class APIHelper
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse response;
        public void SetUrl(string baseUrl, string endpoint)
        {
            //var url = Path.Combine(baseUrl, endpoint);
            var url = baseUrl + endpoint;
            client = new RestClient(url);
        }
        public RestRequest CreateGetRequest()
        {
            request = new RestRequest()
            {
                Method = Method.Get
            };
            request.AddHeader("Accept", "application/json");
            return request;
        }
        public RestRequest CreatePostRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Post
            };
            request.AddHeader("Accept", "application/json");
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }
        public T GetContent<T>(RestResponse response)
        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }
        public RestResponse ExecuteRequest(RestRequest restRequest)
        {
            response = client.Execute(restRequest);
            return response;
        }
    }
}
