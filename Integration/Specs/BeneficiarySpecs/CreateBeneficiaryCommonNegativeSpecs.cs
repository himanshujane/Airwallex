using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tests.Fixtures;
using Tests.Helper.Application;
using Tests.Models.Request;
using Tests.TestDataFactory.BeneficiaryTestData.BeneficiaryInvalidTestData;
using Tests.Utility;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Specs.BeneficiarySpecs
{
    public class CreateBeneficiaryCommonNegativeSpecs : IClassFixture<BaseAppFixture>
    {
        private readonly BeneficiaryHelper _beneficiaryHelper;
        private readonly Dictionary<string, string> _headers;

        public CreateBeneficiaryCommonNegativeSpecs(BaseAppFixture app, ITestOutputHelper output)
        {
            _beneficiaryHelper = new BeneficiaryHelper(app.HttpClient, output);
            _headers = app.AuthTokenHeader;
        }

        [Theory]
        [CreateBeneficiaryCommonInvalidTestData]
        public async Task TestCreateBeneficiaryShouldReturn400(CreateBeneficiaryRequestDto testData)
        {
            //Act
            var response = await _beneficiaryHelper.CreateBeneficiary(testData.Payload, _headers);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var dResponse = await response.DeserializeErrorResponse();
            Assert.Equal(testData.Expected.Code, dResponse.code);
            Assert.Equal(testData.Expected.Message, dResponse.message);
            Assert.Equal(testData.Expected.Source, dResponse.source);

        }
    }
}