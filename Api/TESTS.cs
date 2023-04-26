using RestAPI.DTO;
using RestSharp;
using System.Net;

namespace RestAPI
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            APIHelper apiHelper = new APIHelper();

            apiHelper.SetUrl(TestData.BaseUrl, TestData.TC1endpoint);
            RestResponse response = apiHelper.ExecuteRequest(apiHelper.CreateGetRequest());

            var posts = apiHelper.GetContent<List<PostsDTO>>(response);

            Assert.That(response.StatusCode.Equals((HttpStatusCode)TestData.TC1statusCode),"Response status code is not equal to 200");

            Assert.That(response.ContentType.Equals(TestData.TC1contentType),"Response content type is not Json");

            Assert.That(posts.SequenceEqual<PostsDTO>(posts.OrderBy(x => x.Id)),"List of posts is not sorted by Id");
        }
        [Test]
        public void Test2()
        {
            APIHelper apiHelper = new APIHelper();

            apiHelper.SetUrl(TestData.BaseUrl, TestData.TC2endpoint);
            RestResponse response = apiHelper.ExecuteRequest(apiHelper.CreateGetRequest());

            var exactPost = apiHelper.GetContent<PostsDTO>(response);

            Assert.That(response.StatusCode.Equals((HttpStatusCode)TestData.TC2statusCode),"Response status code is not equal to 200");
            Assert.That(exactPost.UserId == TestData.TC2expectedUserId && exactPost.Id == TestData.TC2expectedId
                && !exactPost.Title.Equals("") && !exactPost.Body.Equals(""),"Data in gotten post is not equal to expected");
        }
        [Test]
        public void Test3()
        {
            APIHelper apiHelper = new APIHelper();

            apiHelper.SetUrl(TestData.BaseUrl, TestData.TC3endpoint);
            RestResponse response = apiHelper.ExecuteRequest(apiHelper.CreateGetRequest());

            Assert.That(response.StatusCode.Equals((HttpStatusCode)TestData.TC3statusCode),"Response status code is not equal to 404");

            Assert.That(response.Content.Equals("{}"),"Response body is not empty of data");
        }
        [Test]
        public void Test4()
        {
            APIHelper apiHelper = new APIHelper();

            PostsDTO post = new PostsDTO(TestData.TC4userId,Randomize.GetRandomString(TestData.TC4randomStringLength), Randomize.GetRandomString(TestData.TC4randomStringLength));

            apiHelper.SetUrl(TestData.BaseUrl, TestData.TC4endpoint);
            RestResponse response = apiHelper.ExecuteRequest(apiHelper.CreatePostRequest<PostsDTO>(post));

            Assert.That(response.StatusCode.Equals((HttpStatusCode)TestData.TC4statusCode), "Response status code is not equal to 201");

            PostsDTO respondedPost = apiHelper.GetContent<PostsDTO>(response);

            Assert.That(respondedPost.Equals(post),"Data in response is not equal to requested");
        }
        [Test]
        public void Test5()
        {
            APIHelper apiHelper = new APIHelper();
            UsersDTO user = JsonUtils.GetUserFromJson(Path.Combine(Environment.CurrentDirectory,TestData.TC5userFilePath));

            apiHelper.SetUrl(TestData.BaseUrl, TestData.TC5endpoint);
            RestResponse response = apiHelper.ExecuteRequest(apiHelper.CreateGetRequest());

            var listOfUsers = apiHelper.GetContent<List<UsersDTO>>(response);

            Assert.That(response.StatusCode.Equals((HttpStatusCode)TestData.TC5statusCode), "Response status code is not equal to 200");

            foreach (UsersDTO u in listOfUsers)
            {
                if (u.Id == TestData.TC5expectedId)
                {
                    Assert.That(user.Equals(u),"Data of exact user in List is not equal to expected");
                    break;
                }
            }
        }
        [Test]
        public void Test6()
        {
            APIHelper apiHelper = new APIHelper();
            UsersDTO user = JsonUtils.GetUserFromJson(Path.Combine(Environment.CurrentDirectory, TestData.TC5userFilePath));

            apiHelper.SetUrl(TestData.BaseUrl, TestData.TC6endpoint);
            RestResponse response = apiHelper.ExecuteRequest(apiHelper.CreateGetRequest());

            var exactUser = apiHelper.GetContent<UsersDTO>(response);

            Assert.That(response.StatusCode.Equals((HttpStatusCode)TestData.TC6statusCode), "Response status code is not equal to 200");

            Assert.That(exactUser.Equals(user), "Data of user is not equal to expected");
        }

    }   
}