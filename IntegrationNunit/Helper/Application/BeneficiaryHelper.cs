using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using NunitTests.Models.Request;
using NunitTests.Models.Response;
using NunitTests.Utility;

namespace NunitTests.Helper.Application
{
    public class BeneficiaryHelper
    {
        private readonly HttpClient _httpClient;

        public BeneficiaryHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateBeneficiary(CreateBeneficiaryPayloadDto objPayload,
            Dictionary<string, string> headers)
        {
            const string url = EndpointUtil.CreateBeneficiaryUrl;
            Console.WriteLine($"*** Request URL : {url}\n");
            Console.WriteLine($"*** Auth Header : {headers.First()}\n");

            var payload = JsonUtil.ConvertToHttpContent(objPayload);
            Console.WriteLine($"*** Request : {HttpUtil.HttpContentToString(payload)}\n");

            var response = await _httpClient.Post(url, payload, headers);
            return response;
        }

        public static void AssertBeneficiaryDetails(CreateBeneficiaryPayloadDto request,
            BeneficiaryCreatedResponseDto response)
        {
            Assert.AreEqual(request.nickname, response.nickname);
            Assert.AreEqual(request.payer_entity_type, response.payer_entity_type);
            Assert.AreEqual(request.payment_methods, response.payment_methods);

            Assert.AreEqual(request.beneficiary.company_name, response.beneficiary.company_name);
            Assert.AreEqual(request.beneficiary.entity_type, response.beneficiary.entity_type);
            Assert.AreEqual(request.beneficiary.additional_info.personal_email,
                response.beneficiary.additional_info.personal_email);

            Assert.AreEqual(request.beneficiary.address.city, response.beneficiary.address.city);
            Assert.AreEqual(request.beneficiary.address.country_code, response.beneficiary.address.country_code);
            Assert.AreEqual(request.beneficiary.address.postcode, response.beneficiary.address.postcode);
            Assert.AreEqual(request.beneficiary.address.state, response.beneficiary.address.state);
            Assert.AreEqual(request.beneficiary.address.street_address, response.beneficiary.address.street_address);

            Assert.AreEqual(request.beneficiary.bank_details.account_currency,
                response.beneficiary.bank_details.account_currency);
            Assert.AreEqual(request.beneficiary.bank_details.account_name,
                response.beneficiary.bank_details.account_name);
            Assert.AreEqual(request.beneficiary.bank_details.account_number,
                response.beneficiary.bank_details.account_number);
            Assert.AreEqual(request.beneficiary.bank_details.account_routing_type1,
                response.beneficiary.bank_details.account_routing_type1);
            Assert.AreEqual(request.beneficiary.bank_details.bank_country_code,
                response.beneficiary.bank_details.bank_country_code);
            Assert.AreEqual(request.beneficiary.bank_details.bank_name, response.beneficiary.bank_details.bank_name);
            Assert.AreEqual(request.beneficiary.bank_details.swift_code, response.beneficiary.bank_details.swift_code);
        }
    }
}