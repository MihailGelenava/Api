using Api.Configuration;
using Newtonsoft.Json;
using RestSharp;
using Models;

namespace Api
{
    public static class ApiHelper
    {
        private static readonly RestClient client = new RestClient(TestConfig.BaseUrl);
        public static RestResponse GetAllPosts()
        {
            RestRequest request = new RestRequest(TestConfig.AllPostsEndpoint, Method.Get);
            request.AddHeader("Accept", "application/json");
            return client.Execute(request);
        }
        public static RestResponse GetPostById(int id) 
        {
            RestRequest request = new RestRequest(TestConfig.AllPostsEndpoint + "/" + id.ToString(), Method.Get);
            request.AddHeader("Accept", "application/json");
            return client.Execute(request);
        }
        public static RestResponse PostPost(PostModel payload)
        {
            RestRequest request = new RestRequest(TestConfig.AllPostsEndpoint,Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request);
        }
        public static RestResponse GetAllUsers()
        {
            RestRequest request = new RestRequest(TestConfig.AllUsersEndpoint, Method.Get);
            request.AddHeader("Accept", "application/json");
            return client.Execute(request);
        }
        public static RestResponse GetUserById(int id)
        {
            RestRequest request = new RestRequest(TestConfig.AllUsersEndpoint + "/" + id.ToString(), Method.Get);
            request.AddHeader("Accept", "application/json");
            return client.Execute(request);
        }
        public static T GetContent<T>(RestResponse response)
        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }
        
    }
}
