using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tests.Fixtures;
using Tests.Helper.Application;
using Tests.Models.Request;
using Tests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData;
using Tests.Utility;
using Xunit;
using Xunit.Abstractions;
using static Tests.Helper.Application.BeneficiaryHelper;

namespace Tests.Specs.BeneficiarySpecs
{
    public class CreateBeneficiaryPositiveSpecs : IClassFixture<BaseAppFixture>
    {
        private readonly BeneficiaryHelper _beneficiaryHelper;
        private readonly Dictionary<string, string> _headers;

        public CreateBeneficiaryPositiveSpecs(BaseAppFixture app, ITestOutputHelper output)
        {
            _beneficiaryHelper = new BeneficiaryHelper(app.HttpClient, output);
            _headers = app.AuthTokenHeader;
        }

        [Theory]
        [CreateBeneficiaryCommonValidTestData]
        [CreateBeneficiaryUnitedStatesValidTestData]
        [CreateBeneficiaryChinaValidTestData]
        [CreateBeneficiaryAustraliaValidTestData]
        public async Task TestCreateBeneficiaryShouldReturn201(CreateBeneficiaryRequestDto testData)
        {
            //Act
            var response = await _beneficiaryHelper.CreateBeneficiary(testData.Payload, _headers);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var dResponse = await response.DeserializeCreateBeneficiary();
            Assert.NotEmpty(dResponse.beneficiary_id);
            Assert.InRange(dResponse.beneficiary_id.Length, 30, 40);
            AssertBeneficiaryDetails(testData.Payload, dResponse);
        }
    }
}