using System.Collections;
using System.Collections.Generic;
using NunitTests.Models.Request;
using static NunitTests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData.CreateBeneficiaryCommonValidTestData;

namespace NunitTests.TestDataFactory.BeneficiaryTestData.BeneficiaryInvalidTestData
{
    public class CreateBeneficiaryCommonInvalidTestData : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            //***
            var paymentMethodInvalid = GetDefaultCreateBeneficiaryPayload();
            paymentMethodInvalid.payment_methods = new List<string> {"Invalid"};
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Payment Method Invalid",
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
            var paymentMethodNull = GetDefaultCreateBeneficiaryPayload();
            paymentMethodNull.payment_methods = new List<string> {null};
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Payment Method Null",
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
            var paymentMethodEmpty = GetDefaultCreateBeneficiaryPayload();
            paymentMethodEmpty.payment_methods = new List<string> {""};
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Payment Method Empty",
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
            var bankCountryCodeInvalid = GetDefaultCreateBeneficiaryPayload();
            bankCountryCodeInvalid.beneficiary.bank_details.bank_country_code = "XX";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Bank Country Code Invalid",
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
            var bankCountryCodeNull = GetDefaultCreateBeneficiaryPayload();
            bankCountryCodeNull.beneficiary.bank_details.bank_country_code = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Bank Country Code Null",
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
            var bankCountryCodeEmpty = GetDefaultCreateBeneficiaryPayload();
            bankCountryCodeEmpty.beneficiary.bank_details.bank_country_code = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Bank Country Code Empty",
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
            var bankCountryCodeHasSpace = GetDefaultCreateBeneficiaryPayload();
            bankCountryCodeHasSpace.beneficiary.bank_details.bank_country_code = " ";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Bank Country Code Has Space",
                    Payload = bankCountryCodeHasSpace,
                    Expected = new
                    {
                        Code = "field_required",
                        Message = "must not be empty",
                        Source = "beneficiary.bank_details.bank_country_code"
                    }
                }
            };

            //***
            var bankCountryCodeInteger = GetDefaultCreateBeneficiaryPayload();
            bankCountryCodeInteger.beneficiary.bank_details.bank_country_code = 12;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Bank Country Code As Integer",
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
            var bankCountryCodeSpecialChar = GetDefaultCreateBeneficiaryPayload();
            bankCountryCodeSpecialChar.beneficiary.bank_details.bank_country_code = "*";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Bank Country Code As Special Char",
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
            var accountNameLessThan2 = GetDefaultCreateBeneficiaryPayload();
            accountNameLessThan2.beneficiary.bank_details.account_name = "a";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Account Name Length Less Than 2",
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
            var accountNameGreaterThan200 = GetDefaultCreateBeneficiaryPayload();
            accountNameGreaterThan200.beneficiary.bank_details.account_name =
                "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijx";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Account Name Length Greater Than 200",
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
            var accountNameEmpty = GetDefaultCreateBeneficiaryPayload();
            accountNameEmpty.beneficiary.bank_details.account_name = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Account Name Empty",
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
            var accountNameNull = GetDefaultCreateBeneficiaryPayload();
            accountNameNull.beneficiary.bank_details.account_name = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Account Name Null",
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
            var accountNameHasEmojis = GetDefaultCreateBeneficiaryPayload();
            accountNameHasEmojis.beneficiary.bank_details.account_name = "Firstname 😊 Lastname";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Account Name Has Emojis",
                    Payload = accountNameHasEmojis,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should not contain emojis",
                        Source = "beneficiary.bank_details.account_name"
                    }
                }
            };

            //***
            var accountNameHasSpace = GetDefaultCreateBeneficiaryPayload();
            accountNameHasSpace.beneficiary.bank_details.account_name = " ";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Account Name Has Space",
                    Payload = accountNameHasSpace,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should contain 2 to 200 characters",
                        Source = "beneficiary.bank_details.account_name"
                    }
                }
            };

            //***
            var accountNameAsInteger = GetDefaultCreateBeneficiaryPayload();
            accountNameAsInteger.beneficiary.bank_details.account_name = 123;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Account Name As Integer",
                    Payload = accountNameAsInteger,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should not be Integer",
                        Source = "beneficiary.bank_details.account_name"
                    }
                }
            };


            //***
            var bankNameHasEmoji = GetDefaultCreateBeneficiaryPayload();
            bankNameHasEmoji.beneficiary.bank_details.bank_name = "JP Morgan 😊";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Bank Name Has Emoji",
                    Payload = bankNameHasEmoji,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should not contain emojis",
                        Source = "beneficiary.bank_details.bank_name"
                    }
                }
            };

            //***
            var bankNameAsNull = GetDefaultCreateBeneficiaryPayload();
            bankNameAsNull.beneficiary.bank_details.bank_name = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Bank Name Null",
                    Payload = bankNameAsNull,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.bank_name"
                    }
                }
            };

            //***
            var bankNameAsEmpty = GetDefaultCreateBeneficiaryPayload();
            bankNameAsEmpty.beneficiary.bank_details.bank_name = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Bank Name Empty",
                    Payload = bankNameAsEmpty,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.bank_name"
                    }
                }
            };

            //***
            var bankNameHasSpace = GetDefaultCreateBeneficiaryPayload();
            bankNameHasSpace.beneficiary.bank_details.bank_name = " ";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Bank Name Has Space",
                    Payload = bankNameHasSpace,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.bank_name"
                    }
                }
            };

            //***
            var bankNameGreaterThan200Char = GetDefaultCreateBeneficiaryPayload();
            bankNameGreaterThan200Char.beneficiary.bank_details.bank_name =
                "Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi Abcdefghi X";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Bank Name Greater Than 200 Char",
                    Payload = bankNameGreaterThan200Char,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should contain 1 to 200 characters",
                        Source = "beneficiary.bank_details.bank_name"
                    }
                }
            };

            //***
            var accountCurrencyNull = GetDefaultCreateBeneficiaryPayload();
            accountCurrencyNull.beneficiary.bank_details.account_currency = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Account Currency Null",
                    Payload = accountCurrencyNull,
                    Expected = new
                    {
                        Code = "field_required",
                        Message = "must not be null",
                        Source = "beneficiary.bank_details.account_currency"
                    }
                }
            };

            //***
            var accountCurrencyEmpty = GetDefaultCreateBeneficiaryPayload();
            accountCurrencyEmpty.beneficiary.bank_details.account_currency = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Account Currency Empty",
                    Payload = accountCurrencyEmpty,
                    Expected = new
                    {
                        Code = "invalid_argument",
                        Message =
                            "beneficiary.bank_details.account_currency is not of the expected type; please refer to our API documentation",
                        Source = "beneficiary.bank_details.account_currency"
                    }
                }
            };

            //***
            var accountCurrencyInvalid = GetDefaultCreateBeneficiaryPayload();
            accountCurrencyInvalid.beneficiary.bank_details.account_currency = "PPP";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Account Currency Invalid",
                    Payload = accountCurrencyInvalid,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message =
                            "Should be one of the following: [AUD, CAD, CNY, EUR, GBP, HKD, IDR, INR, JPY, MYR, NZD, PHP, SGD, THB, USD, VND, CHF, KRW, BDT, LKR, TRY, PKR, NPR, DKK, NOK, SEK, CZK, HUF, HRK, RON, PLN, MXN, ZAR, ILS, BHD, EGP, SAR, AED]",
                        Source = "beneficiary.bank_details.account_currency"
                    }
                }
            };

            //***
            var accountCurrencyHasSpace = GetDefaultCreateBeneficiaryPayload();
            accountCurrencyHasSpace.beneficiary.bank_details.account_currency = " ";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Account Currency Has Space",
                    Payload = accountCurrencyHasSpace,
                    Expected = new
                    {
                        Code = "invalid_argument",
                        Message =
                            "beneficiary.bank_details.account_currency is not of the expected type; please refer to our API documentation",
                        Source = "beneficiary.bank_details.account_currency"
                    }
                }
            };

            //***
            var swiftCodeNull = GetDefaultCreateBeneficiaryPayload();
            swiftCodeNull.beneficiary.bank_details.swift_code = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Swift Code Null",
                    Payload = swiftCodeNull,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.swift_code"
                    }
                }
            };

            //***
            var swiftCodeEmpty = GetDefaultCreateBeneficiaryPayload();
            swiftCodeEmpty.beneficiary.bank_details.swift_code = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Swift Code Empty",
                    Payload = swiftCodeEmpty,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.swift_code"
                    }
                }
            };

            //***
            var swiftCodeInvalid = GetDefaultCreateBeneficiaryPayload();
            swiftCodeInvalid.beneficiary.bank_details.swift_code = "Invalid";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Swift Code Invalid",
                    Payload = swiftCodeInvalid,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should be a valid and supported SWIFT code / BIC",
                        Source = "beneficiary.bank_details.swift_code"
                    }
                }
            };

            //***
            var swiftCodeHasSpace = GetDefaultCreateBeneficiaryPayload();
            swiftCodeHasSpace.beneficiary.bank_details.swift_code = " ";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "Swift Code Has Space",
                    Payload = swiftCodeHasSpace,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should be a valid and supported SWIFT code / BIC",
                        Source = "beneficiary.bank_details.swift_code"
                    }
                }
            };
        }
    }
}