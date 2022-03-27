using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using NunitTests.Models.Request;
using NunitTests.TestDataFactory.BeneficiaryTestData.BeneficiaryInvalidTestData;
using NunitTests.Utility;

namespace NunitTests.Specs.BeneficiarySpecs
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    [FixtureLifeCycleAttribute(LifeCycle.InstancePerTestCase)]
    public class CreateBeneficiaryCountrySpecificNegativeSpecs : CreateBeneficiaryBaseSpec
    {
        [TestCaseSource(typeof(CreateBeneficiaryUnitedStatesInvalidTestData))]
        [TestCaseSource(typeof(CreateBeneficiaryAustraliaInvalidTestData))]
        [TestCaseSource(typeof(CreateBeneficiaryChinaInvalidTestData))]
        public async Task TestCreateBeneficiaryCountrySpecificShouldReturn400(CreateBeneficiaryRequestDto testData)
        {
            //Act
            Response = await BeneficiaryHelper.CreateBeneficiary(testData.Payload, Headers);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, Response.StatusCode);

            var dResponse = await Response.DeserializeErrorResponse();
            Assert.AreEqual(testData.Expected.Code, dResponse.code);
            Assert.AreEqual(testData.Expected.Message, dResponse.message);
            Assert.AreEqual(testData.Expected.Source, dResponse.source);
        }
    }
}