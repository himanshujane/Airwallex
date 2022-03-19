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
            var invalidPaymentMethod = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            invalidPaymentMethod.payment_methods = new List<string> {"Invalid"};
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Invalid Payment Method",
                    Payload = invalidPaymentMethod,
                    Expected = new
                    {
                        Code = "invalid_argument",
                        Message = "No enum constant com.airwallex.domain.transaction.payment.PaymentMethod.Invalid",
                        Source = "payment_methods"
                    }
                }
            };

            //***
            var nullPaymentMethod = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            nullPaymentMethod.payment_methods = new List<string> {null};
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Null Payment Method",
                    Payload = nullPaymentMethod,
                    Expected = new
                    {
                        Code = "operation_failed",
                        Message = "Request cannot be processed. Please contact customer support (ER01",
                        Source = ""
                    }
                }
            };

            //***
            var emptyPaymentMethod = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            emptyPaymentMethod.payment_methods = new List<string> {""};
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Empty Payment Method",
                    Payload = emptyPaymentMethod,
                    Expected = new
                    {
                        Code = "invalid_argument",
                        Message = "No enum constant com.airwallex.domain.transaction.payment.PaymentMethod.Invalid",
                        Source = "payment_methods"
                    }
                }
            };

            //***
            var invalidBankCountryCode = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            invalidBankCountryCode.beneficiary.bank_details.bank_country_code = "XX";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Invalid Bank Country Code",
                    Payload = invalidBankCountryCode,
                    Expected = new
                    {
                        Code = "invalid_argument",
                        Message = "XX is not a valid type",
                        Source = "beneficiary.bank_details.bank_country_code"
                    }
                }
            };

            //***
            var nullBankCountryCode = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            nullBankCountryCode.beneficiary.bank_details.bank_country_code = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Null Bank Country Code",
                    Payload = nullBankCountryCode,
                    Expected = new
                    {
                        Code = "field_required",
                        Message = "must not be null",
                        Source = "beneficiary.bank_details.bank_country_code"
                    }
                }
            };

            //***
            var emptyBankCountryCode = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            emptyBankCountryCode.beneficiary.bank_details.bank_country_code = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Empty Bank Country Code",
                    Payload = emptyBankCountryCode,
                    Expected = new
                    {
                        Code = "field_required",
                        Message = "must not be empty",
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
            var emptyAccountName = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            emptyAccountName.beneficiary.bank_details.account_name = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Empty Account Name",
                    Payload = emptyAccountName,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_name"
                    }
                }
            };

            //***
            var nullAccountName = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            nullAccountName.beneficiary.bank_details.account_name = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Null Account Name",
                    Payload = nullAccountName,
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
            var emptyAccountNumberForUS = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            emptyAccountNumberForUS.beneficiary.bank_details.account_number = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Empty US Account Number",
                    Payload = emptyAccountNumberForUS,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var nullAccountNumberForUS = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            nullAccountNumberForUS.beneficiary.bank_details.account_number = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Null US Account Number",
                    Payload = nullAccountNumberForUS,
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
            var emptyAccountNumberForAU = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            emptyAccountNumberForAU.beneficiary.bank_details.account_number = "";
            emptyAccountNumberForAU.beneficiary.bank_details.bank_country_code = "AU";
            emptyAccountNumberForAU.beneficiary.bank_details.swift_code = "AAYBAU2S";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Empty AU Account Number",
                    Payload = emptyAccountNumberForAU,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var nullAccountNumberForAU = CreateBeneficiaryValidTestData.GetDefaultCreateBeneficiaryPayload();
            nullAccountNumberForAU.beneficiary.bank_details.account_number = null;
            nullAccountNumberForAU.beneficiary.bank_details.bank_country_code = "AU";
            nullAccountNumberForAU.beneficiary.bank_details.swift_code = "AAYBAU2S";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "Create Beneficiary: Null AU Account Number",
                    Payload = nullAccountNumberForAU,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };
        }
    }
}