using System;
using System.Collections.Generic;
using System.Net.Http;
using NUnit.Framework;
using NunitTests.Fixtures;
using NunitTests.Helper.Application;

namespace NunitTests.Specs.BeneficiarySpecs
{
    public class CreateBeneficiaryBaseSpec : ReportFixture
    {
        public static Dictionary<string, string> Headers;
        public BeneficiaryHelper BeneficiaryHelper;

        [OneTimeSetUp]
        public new static void OneTimeSetUp()
        {
            var httpClient = new HttpClient {BaseAddress = new Uri(EnvironmentFixture.Config.TestUrl)};
            var authHelper = new AuthHelper(httpClient);
            Headers = authHelper.GetAuthToken().GetAwaiter().GetResult();
        }


        [SetUp]
        public new void SetUp()
        {
            var httpClient = new HttpClient {BaseAddress = new Uri(EnvironmentFixture.Config.TestUrl)};
            BeneficiaryHelper = new BeneficiaryHelper(httpClient);
        }
    }
}