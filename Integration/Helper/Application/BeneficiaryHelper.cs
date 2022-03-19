using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tests.Models.Request;
using Tests.Models.Response;
using Tests.Utility;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Helper.Application
{
    public class BeneficiaryHelper
    {
        private readonly HttpClient _httpClient;
        private readonly ITestOutputHelper _output;

        public BeneficiaryHelper(HttpClient httpClient, ITestOutputHelper output)
        {
            _httpClient = httpClient;
            _output = output;
        }

        public async Task<HttpResponseMessage> CreateBeneficiary(CreateBeneficiaryPayloadDto objPayload,
            Dictionary<string, string> headers)
        {
            const string url = EndpointUtil.CreateBeneficiaryUrl;
            _output.WriteLine($"*** Request URL : {url}");

            var payload = JsonUtil.ConvertToHttpContent(objPayload);
            _output.WriteLine($"*** Request : {HttpUtil.HttpContentToString(payload)}");

            var response = await _httpClient.Post(url, payload, headers);
            _output.WriteLine($"*** Response : {HttpUtil.HttpResponseToString(response)}");

            return response;
        }

        public void AssertBeneficiaryDetails(CreateBeneficiaryPayloadDto request,
            BeneficiaryCreatedResponseDto response)
        {
            Assert.Equal(request.nickname, response.nickname);
            Assert.Equal(request.payer_entity_type, response.payer_entity_type);
            Assert.Equal(request.payment_methods, response.payment_methods);

            Assert.Equal(request.beneficiary.company_name, response.beneficiary.company_name);
            Assert.Equal(request.beneficiary.entity_type, response.beneficiary.entity_type);
            Assert.Equal(request.beneficiary.additional_info.personal_email, response.beneficiary.additional_info.personal_email);
            
            Assert.Equal(request.beneficiary.address.city, response.beneficiary.address.city);
            Assert.Equal(request.beneficiary.address.country_code, response.beneficiary.address.country_code);
            Assert.Equal(request.beneficiary.address.postcode, response.beneficiary.address.postcode);
            Assert.Equal(request.beneficiary.address.state, response.beneficiary.address.state);
            Assert.Equal(request.beneficiary.address.street_address, response.beneficiary.address.street_address);
            
            Assert.Equal(request.beneficiary.bank_details.account_currency, response.beneficiary.bank_details.account_currency);
            Assert.Equal(request.beneficiary.bank_details.account_name, response.beneficiary.bank_details.account_name);
            Assert.Equal(request.beneficiary.bank_details.account_number, response.beneficiary.bank_details.account_number);
            Assert.Equal(request.beneficiary.bank_details.account_routing_type1, response.beneficiary.bank_details.account_routing_type1);
            Assert.Equal(request.beneficiary.bank_details.bank_country_code, response.beneficiary.bank_details.bank_country_code);
            Assert.Equal(request.beneficiary.bank_details.bank_name, response.beneficiary.bank_details.bank_name);
            Assert.Equal(request.beneficiary.bank_details.swift_code, response.beneficiary.bank_details.swift_code);
        }
    }
}