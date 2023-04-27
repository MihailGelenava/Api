using Models;
using RestSharp;
using System.Net;
using Api.TestsData;
using Api.Utils;
using Aquality.Selenium.Browsers;

namespace Api.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup(){}

        [Test]
        public void TC0001_GetAllPosts()
        {
            AqualityServices.Logger.Info("Sending GET request to get all posts");

            RestResponse response = ApiHelper.GetAllPosts();

            AqualityServices.Logger.Info("Deserialize Rest response to list of posts");

            var posts = ApiHelper.GetContent<List<PostModel>>(response);

            Assert.That(response.StatusCode.Equals((HttpStatusCode)TestData.TC1statusCode), "Response status code is not equal to 200");

            Assert.That(response.ContentType.Equals(TestData.TC1contentType), "Response content type is not Json");

            Assert.That(posts.SequenceEqual(posts.OrderBy(x => x.Id)), "List of posts is not sorted by Id");
        }
        [Test]
        public void TC0002_GetPostById()
        {
            AqualityServices.Logger.Info("Sending GET request to get exact post by id");

            RestResponse response = ApiHelper.GetPostById(TestData.TC2postId);

            AqualityServices.Logger.Info("Deserialize Rest response to Post object");

            var exactPost = ApiHelper.GetContent<PostModel>(response);

            Assert.That(response.StatusCode.Equals((HttpStatusCode)TestData.TC2statusCode), "Response status code is not equal to 200");

            Assert.That(exactPost.UserId == TestData.TC2expectedUserId && exactPost.Id == TestData.TC2postId
                && !exactPost.Title.Equals("") && !exactPost.Body.Equals(""), "Data in gotten post is not equal to expected");
        }
        [Test]
        public void TC0003_GetNonExistentPost()
        {
            AqualityServices.Logger.Info("Sending GET request to get exact post by id (non-existent)");

            RestResponse response = ApiHelper.GetPostById(TestData.TC3postId);

            Assert.That(response.StatusCode.Equals((HttpStatusCode)TestData.TC3statusCode), "Response status code is not equal to 404");

            Assert.That(response.Content.Equals(TestData.TC3expectedResponseBody), "Response body is not empty of data");
        }
        [Test]
        public void TC0004_PostPost()
        {
            AqualityServices.Logger.Info("Init Post object");

            PostModel post = new PostModel(TestData.TC4userId, Randomize.GetRandomString(TestData.TC4randomStringLength), Randomize.GetRandomString(TestData.TC4randomStringLength));

            AqualityServices.Logger.Info("Sending POST request to post Post");

            RestResponse response = ApiHelper.PostPost(post);

            Assert.That(response.StatusCode.Equals((HttpStatusCode)TestData.TC4statusCode), "Response status code is not equal to 201");

            AqualityServices.Logger.Info("Deserialize Rest response to Post object");

            PostModel respondedPost = ApiHelper.GetContent<PostModel>(response);

            Assert.That(respondedPost.Equals(post), "Data in response is not equal to requested");
        }
        [Test]
        public void TC0005_GetAllUsers()
        {
            AqualityServices.Logger.Info("Init User object");

            UserModel user = TestData.TC5user;

            AqualityServices.Logger.Info("Sending GET request to get all users");

            RestResponse response = ApiHelper.GetAllUsers();

            AqualityServices.Logger.Info("Deserialize Rest response to list of User objects");

            var listOfUsers = ApiHelper.GetContent<List<UserModel>>(response);

            Assert.That(response.StatusCode.Equals((HttpStatusCode)TestData.TC5statusCode), "Response status code is not equal to 200");

            Assert.That(listOfUsers.IndexOf(user)!=-1, "Data of exact user in List is not equal to expected");

        }
        [Test]
        public void TC0006_GetUserById()
        {
            AqualityServices.Logger.Info("Init User object");

            UserModel user = TestData.TC5user;

            AqualityServices.Logger.Info("Sending GET request to get exact user by id");

            RestResponse response = ApiHelper.GetUserById(TestData.TC6userId);

            AqualityServices.Logger.Info("Deserialize Rest response to User object");

            var exactUser = ApiHelper.GetContent<UserModel>(response);

            Assert.That(response.StatusCode.Equals((HttpStatusCode)TestData.TC6statusCode), "Response status code is not equal to 200");

            Assert.That(exactUser.Equals(user), "Data of user is not equal to expected");
        }

    }
}