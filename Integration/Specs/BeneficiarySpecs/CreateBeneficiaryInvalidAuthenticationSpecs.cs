using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tests.Fixtures;
using Tests.Helper.Application;
using Tests.Utility;
using Xunit;
using Xunit.Abstractions;
using static Tests.Helper.General.ConstantHelper;
using static Tests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData.CreateBeneficiaryCommonValidTestData;

namespace Tests.Specs.BeneficiarySpecs
{
    public class CreateBeneficiaryInvalidAuthenticationSpecs : IClassFixture<BaseAppFixture>
    {
        private readonly BeneficiaryHelper _beneficiaryHelper;

        public CreateBeneficiaryInvalidAuthenticationSpecs(BaseAppFixture app, ITestOutputHelper output)
        {
            _beneficiaryHelper = new BeneficiaryHelper(app.HttpClient, output);
        }

        [Theory]
        [InlineData("NoAuth", "NoAuth")]
        [InlineData(HeaderKeyAuth, "Basic")]
        [InlineData(HeaderKeyAuth, "Bearer")]
        [InlineData(HeaderKeyAuth, HeaderInvalidAuthToken)]
        [InlineData(HeaderKeyAuth, HeaderInvalidBasicAuth)]
        public async Task TestCreateBeneficiaryShouldReturn401(string authKey, string authValue)
        {
            //Arrange
            var headers = new Dictionary<string, string> {{authKey, authValue}};

            //Act
            var response = await _beneficiaryHelper.CreateBeneficiary(GetDefaultCreateBeneficiaryPayload(), headers);

            //Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

            var dResponse = await response.DeserializeErrorResponse();
            Assert.Equal(ErrorUnauthorized, dResponse.code);
            Assert.Equal(ErrorAccessDenied, dResponse.message);
        }
    }
}