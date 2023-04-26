using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace RestAPI
{
    public static class TestData
    {
        private static ISettingsFile TestDataFile => new JsonSettingsFile("TestData\\TestData.json");
        public static string BaseUrl => TestDataFile.GetValue<string>("baseUrl");
        public static string TC1endpoint => TestDataFile.GetValue<string>("TC1.endpoint");
        public static int TC1statusCode => TestDataFile.GetValue<int>("TC1.statusCode");
        public static string TC1contentType => TestDataFile.GetValue<string>("TC1.contentType");
        public static string TC2endpoint => TestDataFile.GetValue<string>("TC2.endpoint");
        public static int TC2statusCode => TestDataFile.GetValue<int>("TC2.statusCode");
        public static int TC2expectedUserId => TestDataFile.GetValue<int>("TC2.expectedUserId");
        public static int TC2expectedId => TestDataFile.GetValue<int>("TC2.expectedId");
        public static string TC3endpoint => TestDataFile.GetValue<string>("TC3.endpoint");
        public static int TC3statusCode => TestDataFile.GetValue<int>("TC3.statusCode");
        public static string TC4endpoint => TestDataFile.GetValue<string>("TC4.endpoint");
        public static int TC4statusCode => TestDataFile.GetValue<int>("TC4.statusCode");
        public static int TC4userId => TestDataFile.GetValue<int>("TC4.userId");
        public static int TC4randomStringLength => TestDataFile.GetValue<int>("TC4.randomStringLength");
        public static string TC5endpoint => TestDataFile.GetValue<string>("TC5.endpoint");
        public static int TC5statusCode => TestDataFile.GetValue<int>("TC5.statusCode");
        public static string TC5userFilePath => TestDataFile.GetValue<string>("TC5.userFilePath");
        public static int TC5expectedId => TestDataFile.GetValue<int>("TC5.expectedId");
        public static string TC6endpoint => TestDataFile.GetValue<string>("TC6.endpoint");
        public static int TC6statusCode => TestDataFile.GetValue<int>("TC6.statusCode");
    }
}
