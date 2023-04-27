using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace Api.Configuration
{
    public static class TestConfig
    {
        private static ISettingsFile TestDataFile => new JsonSettingsFile("testConfig.json");

        public static string BaseUrl => TestDataFile.GetValue<string>("baseUrl");
        public static string AllPostsEndpoint => TestDataFile.GetValue<string>("allPostsEndpoint");
        public static string AllUsersEndpoint => TestDataFile.GetValue<string>("allUsersEndpoint");
    }
}
