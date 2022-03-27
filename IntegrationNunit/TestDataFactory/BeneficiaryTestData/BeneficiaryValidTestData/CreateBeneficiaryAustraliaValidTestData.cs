using System.Collections;
using System.Collections.Generic;
using NunitTests.Models.Request;

namespace NunitTests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData
{
    public class CreateBeneficiaryAustraliaValidTestData : IEnumerable
    {
        public IEnumerator GetEnumerator()
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
                    TestcaseName = "AU - Australia",
                    Payload = createBeneficiaryForAU
                }
            };

            //***
            var accountNumberLengthIs15ForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountNumberLengthIs15ForAU.beneficiary.bank_details.account_number = "123456789012345";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "AU Account Number Length is 15",
                    Payload = accountNumberLengthIs15ForAU
                }
            };

            //***
            var accountNumberLengthIs20ForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountNumberLengthIs20ForAU.beneficiary.bank_details.account_number = "12345678901234567890";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "AU Account Number Length is 20",
                    Payload = accountNumberLengthIs20ForAU
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