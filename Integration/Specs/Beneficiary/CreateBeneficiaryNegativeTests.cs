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
    public class CreateBeneficiaryNegativeTests : IClassFixture<BaseAppFixture>
    {
        private readonly BeneficiaryHelper _beneficiaryHelper;
        private readonly Dictionary<string, string> _headers;

        public CreateBeneficiaryNegativeTests(BaseAppFixture app, ITestOutputHelper output)
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
        [CreateBeneficiaryInvalidTestData]
        public async Task TestCreateBeneficiaryReturns400(CreateBeneficiaryRequestDto testData)
        {
            //Act
            var response = await _beneficiaryHelper.CreateBeneficiary(testData.Payload, _headers);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var dResponse = await response.DeserializeErrorResponse();
            Assert.Equal(testData.Expected.Code, dResponse.code);
            Assert.Contains(testData.Expected.Message, dResponse.message);
            Assert.Equal(testData.Expected.Source, dResponse.source);
        }
        
        [Theory]
        [InlineData("NoAuth", "NoAuth")]
        [InlineData(HeaderKeyAuth, "Basic")]
        [InlineData(HeaderKeyAuth, "Bearer")]
        [InlineData(HeaderKeyAuth, HeaderInvalidAuthToken)]
        [InlineData(HeaderKeyAuth, HeaderInvalidBasicAuth)]
        public async Task TestCreateBeneficiaryReturns401(string authKey, string authValue)
        {
            //Arrange
            _headers.Remove(HeaderKeyAuth);
            _headers.Add(authKey, authValue);
            
            //Act
            var response = await _beneficiaryHelper.CreateBeneficiary(CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload(), _headers);

            //Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

            var dResponse = await response.DeserializeErrorResponse();
            Assert.Equal(ErrorUnauthorized, dResponse.code);
            Assert.Equal(ErrorAccessDenied, dResponse.message);
        }
    }
}