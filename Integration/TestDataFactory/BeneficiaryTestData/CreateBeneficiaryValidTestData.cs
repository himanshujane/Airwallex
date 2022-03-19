using System.Collections.Generic;
using System.Reflection;
using Tests.Models.Request;
using Xunit.Sdk;

namespace Tests.TestDataFactory.BeneficiaryTestData
{
    public class CreateBeneficiaryValidTestData : DataAttribute
    {
        public override IEnumerable<CreateBeneficiaryRequestDto[]> GetData(MethodInfo testMethod)
        {
            //***
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary Payment Method as SWIFT",
                    Payload = GetDefaultCreateBeneficiaryPayload()
                }
            };
            
            //***
            var paymentMethodAsLocal = GetDefaultCreateBeneficiaryPayload();
            paymentMethodAsLocal.payment_methods = new List<string>{"LOCAL"};
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary Payment Method as LOCAL",
                    Payload = paymentMethodAsLocal
                }
            };
            
            //***
            
        }
        
        public static CreateBeneficiaryPayloadDto GetDefaultCreateBeneficiaryPayload()
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
                        account_number = "50001121",
                        account_routing_type1 = "aba",
                        bank_country_code = "US",
                        bank_name = "JP Morgan Chase Bank",
                        swift_code = "CHASUS33"
                    },
                    company_name = "ABC University",
                    entity_type = "COMPANY"
                }
            };
        }
    }
}