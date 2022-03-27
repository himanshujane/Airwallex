using System;
using System.Net.Http;
using NUnit.Framework;
using NunitTests.Utility;

namespace NunitTests.Fixtures
{
    /*
    * Purpose of this class is to create and update HTML report
    */

    public class ReportFixture
    {
        private static readonly ReportUtil Report = new();
        public HttpResponseMessage Response;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            Report.StartReport();
        }


        [SetUp]
        public void SetUp()
        {
            Report.CreateTest();
        }


        [TearDown]
        public void TearDown()
        {
            var apiResponse = HttpUtil.HttpContentToString(Response.Content);
            Console.WriteLine($"*** Response : {apiResponse}");
            
            Report.LogApiResponse(apiResponse);
            Report.LogTestStatus();
        }
    }
}