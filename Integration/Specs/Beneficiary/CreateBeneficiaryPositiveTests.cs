using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tests.Fixtures;
using Tests.Helper.Application;
using Tests.Models.Request;
using Tests.TestDataFactory.BeneficiaryTestData;
using Tests.Utility;
using Xunit;
using Xunit.Abstractions;
using static Tests.Helper.General.ConstantHelper;

namespace Tests.Specs.Beneficiary
{
    public class CreateBeneficiaryPositiveTests : IClassFixture<BaseAppFixture>
    {
        private readonly BeneficiaryHelper _beneficiaryHelper;
        private readonly Dictionary<string, string> _headers;

        public CreateBeneficiaryPositiveTests(BaseAppFixture app, ITestOutputHelper output)
        {
            _beneficiaryHelper = new BeneficiaryHelper(app.HttpClient, output);
            _headers = new Dictionary<string, string>
            {
                {
                    HeaderKeyAuth,
                    $"Bearer {app.AuthToken}"
                }
            };
        }

        [Theory]
        [CreateBeneficiaryValidTestData]
        public async Task TestCreateBeneficiaryReturns201(CreateBeneficiaryRequestDto testData)
        {
            //Act
            var response = await _beneficiaryHelper.CreateBeneficiary(testData.Payload, _headers);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var dResponse = await response.DeserializeCreateBeneficiary();
            Assert.NotEmpty(dResponse.beneficiary_id);
            Assert.InRange(dResponse.beneficiary_id.Length, 30, 40);
            _beneficiaryHelper.AssertBeneficiaryDetails(testData.Payload, dResponse);
        }
    }
}