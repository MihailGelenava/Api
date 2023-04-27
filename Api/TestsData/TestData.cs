using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using Models;

namespace Api.TestsData
{
    public static class TestData
    {
        private static ISettingsFile TestDataFile => new JsonSettingsFile("TestData\\testData.json");

        public static int TC1statusCode => TestDataFile.GetValue<int>("TC1.statusCode");
        public static string TC1contentType => TestDataFile.GetValue<string>("TC1.contentType");
        public static int TC2postId => TestDataFile.GetValue<int>("TC2.postId");
        public static int TC2statusCode => TestDataFile.GetValue<int>("TC2.statusCode");
        public static int TC2expectedUserId => TestDataFile.GetValue<int>("TC2.expectedUserId");
        public static int TC3postId => TestDataFile.GetValue<int>("TC3.postId");
        public static int TC3statusCode => TestDataFile.GetValue<int>("TC3.statusCode");
        public static string TC3expectedResponseBody => TestDataFile.GetValue<string>("TC3.expectedResponseBody");
        public static int TC4statusCode => TestDataFile.GetValue<int>("TC4.statusCode");
        public static int TC4userId => TestDataFile.GetValue<int>("TC4.userId");
        public static int TC4randomStringLength => TestDataFile.GetValue<int>("TC4.randomStringLength");
        public static int TC5statusCode => TestDataFile.GetValue<int>("TC5.statusCode");
        public static UserModel TC5user => TestDataFile.GetValue<UserModel>("TC5.user");
        public static int TC5expectedId => TestDataFile.GetValue<int>("TC5.expectedId");
        public static int TC6statusCode => TestDataFile.GetValue<int>("TC6.statusCode");
        public static int TC6userId => TestDataFile.GetValue<int>("TC6.userId");
    }
}
