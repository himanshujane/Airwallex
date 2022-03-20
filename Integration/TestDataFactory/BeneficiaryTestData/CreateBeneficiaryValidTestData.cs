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
                    _TestName = "Create Beneficiary: Payment Method as SWIFT",
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
                    _TestName = "Create Beneficiary: Payment Method as LOCAL",
                    Payload = paymentMethodAsLocal
                }
            };

            //***
            var accountNameLengthIs2 = GetDefaultCreateBeneficiaryPayload();
            accountNameLengthIs2.beneficiary.bank_details.account_name = "ab";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Account Name Length is 2",
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
                    _TestName = "Create Beneficiary: Account Name Length is 100",
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
                    _TestName = "Create Beneficiary: Account Name Length is 200",
                    Payload = accountNameLengthIs200
                }
            };

            //***
            var accountNameAsInteger = GetDefaultCreateBeneficiaryPayload();
            accountNameAsInteger.beneficiary.bank_details.account_name = 123;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Account Name As Integer",
                    Payload = accountNameAsInteger
                }
            };

            //***
            var accountNameAsSpecialChar = GetDefaultCreateBeneficiaryPayload();
            accountNameAsSpecialChar.beneficiary.bank_details.account_name = "!@#$%^&*()_+";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Account Name As Special Char",
                    Payload = accountNameAsSpecialChar
                }
            };
            
            //***
            var accountNumberLenghtIs1ForUS = GetDefaultCreateBeneficiaryPayload();
            accountNumberLenghtIs1ForUS.beneficiary.bank_details.account_number = "1";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: US Account Number Length is 1",
                    Payload = accountNumberLenghtIs1ForUS
                }
            };

            //***
            var accountNumberLenghtIs9ForUS = GetDefaultCreateBeneficiaryPayload();
            accountNumberLenghtIs9ForUS.beneficiary.bank_details.account_number = "123456789";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: US Account Number Length is 9",
                    Payload = accountNumberLenghtIs9ForUS
                }
            };

            //***
            var accountNumberLenghtIs17ForUS = GetDefaultCreateBeneficiaryPayload();
            accountNumberLenghtIs17ForUS.beneficiary.bank_details.account_number = "12345678912345678";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: US Account Number Length is 17",
                    Payload = accountNumberLenghtIs17ForUS
                }
            };

            //***
            var accountNumberLenghtIs6ForAU = GetDefaultCreateBeneficiaryPayload();
            accountNumberLenghtIs6ForAU.beneficiary.bank_details.account_number = "123456";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: AU Account Number Length is 6",
                    Payload = accountNumberLenghtIs6ForAU
                }
            };

            //***
            var accountNumberLenghtIs7ForAU = GetDefaultCreateBeneficiaryPayload();
            accountNumberLenghtIs7ForAU.beneficiary.bank_details.account_number = "1234567";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: AU Account Number Length is 7",
                    Payload = accountNumberLenghtIs7ForAU
                }
            };

            //***
            var accountNumberLenghtIs9ForAU = GetDefaultCreateBeneficiaryPayload();
            accountNumberLenghtIs9ForAU.beneficiary.bank_details.account_number = "123456789";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: AU Account Number Length is 9",
                    Payload = accountNumberLenghtIs9ForAU
                }
            };

            //***
            var accountNumberLenghtIs8ForCN = GetDefaultCreateBeneficiaryPayload();
            accountNumberLenghtIs8ForCN.beneficiary.bank_details.account_number = "12345678";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: CN Account Number Length is 8",
                    Payload = accountNumberLenghtIs8ForCN
                }
            };

            //***
            var accountNumberLenghtIs14ForCN = GetDefaultCreateBeneficiaryPayload();
            accountNumberLenghtIs14ForCN.beneficiary.bank_details.account_number = "12345678912345";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: CN Account Number Length is 14",
                    Payload = accountNumberLenghtIs14ForCN
                }
            };

            //***
            var accountNumberLenghtIs20ForCN = GetDefaultCreateBeneficiaryPayload();
            accountNumberLenghtIs20ForCN.beneficiary.bank_details.account_number = "12345678912345678912";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: CN Account Number Length is 20",
                    Payload = accountNumberLenghtIs20ForCN
                }
            };

            //***
            var swiftCodeLenghtIs11 = GetDefaultCreateBeneficiaryPayload();
            swiftCodeLenghtIs11.beneficiary.bank_details.swift_code = "FTSBUS33SFI";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: US Swift Code Length is 11",
                    Payload = swiftCodeLenghtIs11
                }
            };

            //***
            var swiftCodeForCN = GetDefaultCreateBeneficiaryPayload();
            swiftCodeForCN.beneficiary.bank_details.bank_country_code = "CN";
            swiftCodeForCN.beneficiary.bank_details.swift_code = "ICBKCNBJ";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Swift Code for CN",
                    Payload = swiftCodeForCN
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