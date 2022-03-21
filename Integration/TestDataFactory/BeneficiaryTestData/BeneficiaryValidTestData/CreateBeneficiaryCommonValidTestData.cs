using System.Collections.Generic;
using System.Reflection;
using Tests.Models.Request;
using Xunit.Sdk;

namespace Tests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData
{
    public class CreateBeneficiaryCommonValidTestData : DataAttribute
    {
        public override IEnumerable<CreateBeneficiaryRequestDto[]> GetData(MethodInfo testMethod)
        {
            //***
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Payment Method as SWIFT",
                    Payload = GetDefaultCreateBeneficiaryPayload()
                }
            };

            //***
            var paymentMethodAsLocal = GetDefaultCreateBeneficiaryPayload();
            paymentMethodAsLocal.payment_methods = new List<string> {"LOCAL"};
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Payment Method as LOCAL",
                    Payload = paymentMethodAsLocal
                }
            };

            //***
            var paymentMethodAsLocalAndSwift = GetDefaultCreateBeneficiaryPayload();
            paymentMethodAsLocalAndSwift.payment_methods = new List<string> {"LOCAL", "SWIFT"};
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Payment Method as LOCAL And SWIFT",
                    Payload = paymentMethodAsLocalAndSwift
                }
            };


            //***
            var accountNameLengthIs2 = GetDefaultCreateBeneficiaryPayload();
            accountNameLengthIs2.beneficiary.bank_details.account_name = "ab";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Account Name Length is 2",
                    Payload = accountNameLengthIs2
                }
            };

            //***
            var accountNameLengthIs100 = GetDefaultCreateBeneficiaryPayload();
            accountNameLengthIs100.beneficiary.bank_details.account_name =
                "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghij";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Account Name Length is 100",
                    Payload = accountNameLengthIs100
                }
            };

            //***
            var accountNameLengthIs200 = GetDefaultCreateBeneficiaryPayload();
            accountNameLengthIs200.beneficiary.bank_details.account_name =
                "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghij";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Account Name Length is 200",
                    Payload = accountNameLengthIs200
                }
            };

            //***
            var accountNameAsSpecialChar = GetDefaultCreateBeneficiaryPayload();
            accountNameAsSpecialChar.beneficiary.bank_details.account_name = "!@#$%^&*()_+";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Account Name As Special Char",
                    Payload = accountNameAsSpecialChar
                }
            };

            //***
            var accountNameHasChineseChar = GetDefaultCreateBeneficiaryPayload();
            accountNameHasChineseChar.beneficiary.bank_details.account_name = "大明";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Account Name Has Chinese Char",
                    Payload = accountNameHasChineseChar
                }
            };
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
                        account_routing_value1 = "021000021",
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