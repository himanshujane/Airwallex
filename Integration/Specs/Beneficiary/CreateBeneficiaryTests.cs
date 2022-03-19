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

namespace Tests.Specs.Beneficiary
{
    public class CreateBeneficiaryTests : IClassFixture<BaseAppFixture>
    {
        private readonly BeneficiaryHelper _beneficiaryHelper;
        private readonly Dictionary<string, string> _headers;

        public CreateBeneficiaryTests(BaseAppFixture app, ITestOutputHelper output)
        {
            _beneficiaryHelper = new BeneficiaryHelper(app.HttpClient, output);
            _headers = new Dictionary<string, string>
            {
                {
                    "Authorization",
                    "Bearer eyJhbGciOiJIUzI1NiJ9.eyJqdGkiOiIxNDhjYjE4Mi0wNjYxLTQyYzAtYWZjMC02MWQ0ODdkYjg5NjgiLCJzdWIiOiIyODk2ZWJmZC03YjM5LTRjYjktYTE2My00ZGM5NTkyOGI3MzUiLCJpYXQiOjE2NDc2ODgwNTAsImV4cCI6MTY0NzcwMDA1MCwiYWNjb3VudF9pZCI6IjIyNTQ4MzkyLTM4Y2MtNDFiNy04YjFiLWM1YWNjZDAzNzJhOCIsImRhdGFfY2VudGVyX3JlZ2lvbiI6IkhLIiwidHlwZSI6ImNsaWVudCIsImRjIjoiSEsiLCJpc3NkYyI6IlVTIn0.3dfRvsOlN3tYhbvx7Ucbi4OGYsuvHuFsCRjiSN35n1A"
                }
            };
        }

        [Theory]
        [CreateBeneficiaryValidTestData]
        public async Task TestCreateBeneficiary(CreateBeneficiaryRequestDto testData)
        {
            //Act
            var response = await _beneficiaryHelper.CreateBeneficiary(testData.Payload, _headers);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var dResponse = await response.DeserializeCreateBeneficiary();
            Assert.NotEmpty(dResponse.beneficiary_id);
            Assert.InRange(dResponse.beneficiary_id.Length, 30,40);
            _beneficiaryHelper.AssertBeneficiaryDetails(testData.Payload, dResponse);
        }
    }
}