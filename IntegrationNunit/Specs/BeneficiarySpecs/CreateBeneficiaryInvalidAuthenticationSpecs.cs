using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using NunitTests.Utility;
using static NunitTests.Helper.General.ConstantHelper;
using static NunitTests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData.CreateBeneficiaryCommonValidTestData;

namespace NunitTests.Specs.BeneficiarySpecs
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    [FixtureLifeCycleAttribute(LifeCycle.InstancePerTestCase)]
    public class CreateBeneficiaryInvalidAuthenticationSpecs : CreateBeneficiaryBaseSpec
    {
        [TestCase("NoAuth", "NoAuth")]
        [TestCase(HeaderKeyAuth, "Basic")]
        [TestCase(HeaderKeyAuth, "Bearer")]
        [TestCase(HeaderKeyAuth, HeaderInvalidAuthToken)]
        [TestCase(HeaderKeyAuth, HeaderInvalidBasicAuth)]
        public async Task TestCreateBeneficiaryShouldReturn401(string authKey, string authValue)
        {
            //Arrange
            var headers = new Dictionary<string, string> {{authKey, authValue}};

            //Act
            Response = await BeneficiaryHelper.CreateBeneficiary(GetDefaultCreateBeneficiaryPayload(), headers);

            //Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, Response.StatusCode);

            var dResponse = await Response.DeserializeErrorResponse();
            Assert.AreEqual(ErrorUnauthorized, dResponse.code);
            Assert.AreEqual(ErrorAccessDenied, dResponse.message);
        }
    }
}