using System.Collections.Generic;
using System.Reflection;
using Tests.Models.Request;
using Xunit.Sdk;

namespace Tests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData
{
    public class CreateBeneficiaryChinaValidTestData : DataAttribute
    {
        public override IEnumerable<CreateBeneficiaryRequestDto[]> GetData(MethodInfo testMethod)
        {
            /*
             * This test data verifies
             * Account Number Length is 8 Char
             * Valid Swift Code
             */
            var createBeneficiaryForCN = GetDefaultCreateBeneficiaryChinaPayload();
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "CN - China",
                    Payload = createBeneficiaryForCN
                }
            };

            //***
            var accountNumberLengthIs14ForCN = GetDefaultCreateBeneficiaryChinaPayload();
            accountNumberLengthIs14ForCN.beneficiary.bank_details.account_number = "12345678912345";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "CN Account Number Length is 14",
                    Payload = accountNumberLengthIs14ForCN
                }
            };

            //***
            var accountNumberLengthIs20ForCN = GetDefaultCreateBeneficiaryChinaPayload();
            accountNumberLengthIs20ForCN.beneficiary.bank_details.account_number = "12345678912345678912";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "CN Account Number Length is 20",
                    Payload = accountNumberLengthIs20ForCN
                }
            };
        }

        public static CreateBeneficiaryPayloadDto GetDefaultCreateBeneficiaryChinaPayload()
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
                        account_number = "12345678",
                        account_routing_type1 = "aba",
                        account_routing_value1 = "083064123",
                        bank_country_code = "CN",
                        bank_name = "China Bank",
                        swift_code = "ICBKCNBJ"
                    },
                    company_name = "ABC University",
                    entity_type = "COMPANY"
                }
            };
        }
    }
}