using System.Collections.Generic;
using System.Reflection;
using Tests.Models.Request;
using Xunit.Sdk;

namespace Tests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData
{
    public class CreateBeneficiaryAustraliaValidTestData : DataAttribute
    {
        public override IEnumerable<CreateBeneficiaryRequestDto[]> GetData(MethodInfo testMethod)
        {
            /*
             * This test data verifies
             * Account Number Length is 6 char
             * Valid Swift Code
             * Account_routing_type1 as BSB
             * Account_routing_value1 Length is 6 Char
             */
            var createBeneficiaryForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "AU - Australia",
                    Payload = createBeneficiaryForAU
                }
            };

            //***
            var accountNumberLengthIs7ForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountNumberLengthIs7ForAU.beneficiary.bank_details.account_number = "1234567";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "AU Account Number Length is 7",
                    Payload = accountNumberLengthIs7ForAU
                }
            };

            //***
            var accountNumberLengthIs9ForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountNumberLengthIs9ForAU.beneficiary.bank_details.account_number = "123456789";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "AU Account Number Length is 9",
                    Payload = accountNumberLengthIs9ForAU
                }
            };
        }

        public static CreateBeneficiaryPayloadDto GetDefaultCreateBeneficiaryAustraliaPayload()
        {
            return new CreateBeneficiaryPayloadDto()
            {
                nickname = "ABC University",
                payer_entity_type = "PERSONAL",
                payment_methods = new List<string> {"SWIFT"},
                beneficiary = new BeneficiaryDetailsDto
                {
                    additional_info = new BeneficiaryAdditionalInfoDto
                    {
                        personal_email = "john.walker@gmail.com"
                    },
                    address = new BeneficiaryAddressDto()
                    {
                        city = "Seattle",
                        country_code = "US",
                        postcode = "98104",
                        state = "Washington",
                        street_address = "412 5th Avenue"
                    },
                    bank_details = new BeneficiaryBankDetailsDto()
                    {
                        account_currency = "USD",
                        account_name = "John Walker",
                        account_number = "123456",
                        account_routing_type1 = "bsb",
                        account_routing_value1 = "123456",
                        bank_country_code = "AU",
                        bank_name = "JP Morgan Chase Bank",
                        swift_code = "AAYBAU2S"
                    },
                    company_name = "ABC University",
                    entity_type = "COMPANY"
                }
            };
        }
    }
}