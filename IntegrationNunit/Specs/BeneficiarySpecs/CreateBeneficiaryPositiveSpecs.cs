using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using NunitTests.Models.Request;
using NunitTests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData;
using NunitTests.Utility;
using static NunitTests.Helper.Application.BeneficiaryHelper;

namespace NunitTests.Specs.BeneficiarySpecs
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    [FixtureLifeCycleAttribute(LifeCycle.InstancePerTestCase)]
    public class CreateBeneficiaryPositiveSpecs : CreateBeneficiaryBaseSpec
    {
        [TestCaseSource(typeof(CreateBeneficiaryCommonValidTestData))]
        [TestCaseSource(typeof(CreateBeneficiaryUnitedStatesValidTestData))]
        [TestCaseSource(typeof(CreateBeneficiaryChinaValidTestData))]
        [TestCaseSource(typeof(CreateBeneficiaryAustraliaValidTestData))]
        public async Task TestCreateBeneficiaryShouldReturn201(CreateBeneficiaryRequestDto testData)
        {
            //Act
            Response = await BeneficiaryHelper.CreateBeneficiary(testData.Payload, Headers);

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, Response.StatusCode);

            var dResponse = await Response.DeserializeCreateBeneficiary();
            Assert.IsNotEmpty(dResponse.beneficiary_id);
            Assert.GreaterOrEqual(dResponse.beneficiary_id.Length, 30);
            AssertBeneficiaryDetails(testData.Payload, dResponse);
        }
    }
}