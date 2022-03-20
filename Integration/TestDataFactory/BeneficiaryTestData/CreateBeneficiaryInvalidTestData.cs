using System.Collections.Generic;
using System.Reflection;
using Tests.Models.Request;
using Xunit.Sdk;

namespace Tests.TestDataFactory.BeneficiaryTestData
{
    public class CreateBeneficiaryInvalidTestData : DataAttribute
    {
        public override IEnumerable<CreateBeneficiaryRequestDto[]> GetData(MethodInfo testMethod)
        {
            //***
            var paymentMethodInvalid = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            paymentMethodInvalid.payment_methods = new List<string> {"Invalid"};
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Payment Method Invalid",
                    Payload = paymentMethodInvalid,
                    Expected = new
                    {
                        Code = "invalid_argument",
                        Message = "Invalid is not a valid type",
                        Source = "payment_methods"
                    }
                }
            };

            //***
            var paymentMethodNull = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            paymentMethodNull.payment_methods = new List<string> {null};
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Payment Method Null",
                    Payload = paymentMethodNull,
                    Expected = new
                    {
                        Code = "field_required",
                        Message = "must not be null",
                        Source = "payment_methods"
                    }
                }
            };

            //***
            var paymentMethodEmpty = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            paymentMethodEmpty.payment_methods = new List<string> {""};
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Payment Method Empty",
                    Payload = paymentMethodEmpty,
                    Expected = new
                    {
                        Code = "field_required",
                        Message = "must not be null",
                        Source = "payment_methods"
                    }
                }
            };

            //***
            var bankCountryCodeInvalid = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            bankCountryCodeInvalid.beneficiary.bank_details.bank_country_code = "XX";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Bank Country Code Invalid",
                    Payload = bankCountryCodeInvalid,
                    Expected = new
                    {
                        Code = "invalid_argument",
                        Message = "XX is not a valid type",
                        Source = "beneficiary.bank_details.bank_country_code"
                    }
                }
            };

            //***
            var bankCountryCodeNull = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            bankCountryCodeNull.beneficiary.bank_details.bank_country_code = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Bank Country Code Null",
                    Payload = bankCountryCodeNull,
                    Expected = new
                    {
                        Code = "field_required",
                        Message = "must not be null",
                        Source = "beneficiary.bank_details.bank_country_code"
                    }
                }
            };

            //***
            var bankCountryCodeEmpty = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            bankCountryCodeEmpty.beneficiary.bank_details.bank_country_code = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Bank Country Code Empty",
                    Payload = bankCountryCodeEmpty,
                    Expected = new
                    {
                        Code = "field_required",
                        Message = "must not be empty",
                        Source = "beneficiary.bank_details.bank_country_code"
                    }
                }
            };

            //***
            var bankCountryCodeInteger = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            bankCountryCodeInteger.beneficiary.bank_details.bank_country_code = 12;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Bank Country Code As Integer",
                    Payload = bankCountryCodeInteger,
                    Expected = new
                    {
                        Code = "invalid_argument",
                        Message = "12 is not a valid type",
                        Source = "beneficiary.bank_details.bank_country_code"
                    }
                }
            };
            
            //***
            var bankCountryCodeSpecialChar = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            bankCountryCodeSpecialChar.beneficiary.bank_details.bank_country_code = "*";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Bank Country Code As Special Char",
                    Payload = bankCountryCodeSpecialChar,
                    Expected = new
                    {
                        Code = "invalid_argument",
                        Message = "* is not a valid type",
                        Source = "beneficiary.bank_details.bank_country_code"
                    }
                }
            };
            
            //***
            var accountNameLessThan2 = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountNameLessThan2.beneficiary.bank_details.account_name = "a";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Account Name Length Less Than 2",
                    Payload = accountNameLessThan2,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should contain 2 to 200 characters",
                        Source = "beneficiary.bank_details.account_name"
                    }
                }
            };

            //***
            var accountNameGreaterThan200 = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountNameGreaterThan200.beneficiary.bank_details.account_name =
                "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijx";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Account Name Length Greater Than 200",
                    Payload = accountNameGreaterThan200,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should contain 2 to 200 characters",
                        Source = "beneficiary.bank_details.account_name"
                    }
                }
            };

            //***
            var accountNameEmpty = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountNameEmpty.beneficiary.bank_details.account_name = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Account Name Empty",
                    Payload = accountNameEmpty,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_name"
                    }
                }
            };

            //***
            var accountNameNull = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountNameNull.beneficiary.bank_details.account_name = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Account Name Null",
                    Payload = accountNameNull,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_name"
                    }
                }
            };

            //***
            var accountNumberGreaterThan17ForUS = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountNumberGreaterThan17ForUS.beneficiary.bank_details.account_number = "123456789123456789";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: US Account Number Greater Than 17",
                    Payload = accountNumberGreaterThan17ForUS,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should contain 1 to 17 characters",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountNumberEmpty = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountNumberEmpty.beneficiary.bank_details.account_number = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Account Number Empty",
                    Payload = accountNumberEmpty,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountNumberNull = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountNumberNull.beneficiary.bank_details.account_number = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Account Number Null",
                    Payload = accountNumberNull,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountNumberGreaterThan20ForAU = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountNumberGreaterThan20ForAU.beneficiary.bank_details.account_number = "123456789012345678901";
            accountNumberGreaterThan20ForAU.beneficiary.bank_details.bank_country_code = "AU";
            accountNumberGreaterThan20ForAU.beneficiary.bank_details.swift_code = "AAYBAU2S";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: AU Account Number Greater Than 20",
                    Payload = accountNumberGreaterThan20ForAU,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should contain 6 to 20 characters",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountNumberLessThan6ForAU = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountNumberLessThan6ForAU.beneficiary.bank_details.account_number = "12345";
            accountNumberLessThan6ForAU.beneficiary.bank_details.bank_country_code = "AU";
            accountNumberLessThan6ForAU.beneficiary.bank_details.swift_code = "AAYBAU2S";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: AU Account Number Less Than 6",
                    Payload = accountNumberLessThan6ForAU,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should contain 6 to 20 characters",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountNumberEmptyForAU = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountNumberEmptyForAU.beneficiary.bank_details.account_number = "";
            accountNumberEmptyForAU.beneficiary.bank_details.bank_country_code = "AU";
            accountNumberEmptyForAU.beneficiary.bank_details.swift_code = "AAYBAU2S";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: AU Account Number Empty",
                    Payload = accountNumberEmptyForAU,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountNumberNullForAU = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountNumberNullForAU.beneficiary.bank_details.account_number = null;
            accountNumberNullForAU.beneficiary.bank_details.bank_country_code = "AU";
            accountNumberNullForAU.beneficiary.bank_details.swift_code = "AAYBAU2S";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: AU Account Number Null",
                    Payload = accountNumberNullForAU,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountNumberGreaterThan34ForCN = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountNumberGreaterThan34ForCN.beneficiary.bank_details.account_number = "12345678901234567890123456789012345";
            accountNumberGreaterThan34ForCN.beneficiary.bank_details.bank_country_code = "CN";
            accountNumberGreaterThan34ForCN.beneficiary.bank_details.swift_code = "BKCHCNBJ110";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: CN Account Number Greater Than 34",
                    Payload = accountNumberGreaterThan34ForCN,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should contain 8 to 34 characters",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountNumberLessThan8ForCN = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountNumberLessThan8ForCN.beneficiary.bank_details.account_number = "1234567";
            accountNumberLessThan8ForCN.beneficiary.bank_details.bank_country_code = "CN";
            accountNumberLessThan8ForCN.beneficiary.bank_details.swift_code = "BKCHCNBJ110";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: CN Account Number Less Than 8",
                    Payload = accountNumberLessThan8ForCN,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should contain 8 to 34 characters",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };
            
            //***
            var accountRoutingTypeNullForAU = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountRoutingTypeNullForAU.beneficiary.bank_details.account_number = "123456789";
            accountRoutingTypeNullForAU.beneficiary.bank_details.bank_country_code = "AU";
            accountRoutingTypeNullForAU.beneficiary.bank_details.swift_code = "AAYBAU2S";
            accountRoutingTypeNullForAU.beneficiary.bank_details.account_routing_type1 = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: AU Account Routing Type Null",
                    Payload = accountRoutingTypeNullForAU,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_routing_type1"
                    }
                }
            };
            
            //***
            var accountRoutingTypeEmptyForAU = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            accountRoutingTypeEmptyForAU.beneficiary.bank_details.account_number = "123456789";
            accountRoutingTypeEmptyForAU.beneficiary.bank_details.bank_country_code = "AU";
            accountRoutingTypeEmptyForAU.beneficiary.bank_details.swift_code = "AAYBAU2S";
            accountRoutingTypeEmptyForAU.beneficiary.bank_details.account_routing_type1 = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: AU Account Routing Type Null",
                    Payload = accountRoutingTypeEmptyForAU,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_routing_type1"
                    }
                }
            };
        }
    }
}