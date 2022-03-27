using System.Collections;
using NunitTests.Models.Request;
using static NunitTests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData.CreateBeneficiaryAustraliaValidTestData;

namespace NunitTests.TestDataFactory.BeneficiaryTestData.BeneficiaryInvalidTestData
{
    public class CreateBeneficiaryAustraliaInvalidTestData : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            //***
            var accountNumberGreaterThan20ForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountNumberGreaterThan20ForAU.beneficiary.bank_details.account_number = "123456789012345678901";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "AU Account Number Greater Than 20",
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
            var accountNumberLessThan6ForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountNumberLessThan6ForAU.beneficiary.bank_details.account_number = "12345";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "AU Account Number Less Than 6",
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
            var accountNumberEmptyForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountNumberEmptyForAU.beneficiary.bank_details.account_number = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "AU Account Number Empty",
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
            var accountNumberNullForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountNumberNullForAU.beneficiary.bank_details.account_number = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "AU Account Number Null",
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
            var accountNumberHaveSpecialCharForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountNumberHaveSpecialCharForAU.beneficiary.bank_details.account_number = "123@56";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "AU Account Number Have Special Char",
                    Payload = accountNumberHaveSpecialCharForAU,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should contain alphanumeric characters only",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountRoutingTypeInvalidForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountRoutingTypeInvalidForAU.beneficiary.bank_details.account_routing_type1 = "aba";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "AU Account Routing Type Invalid [aba]",
                    Payload = accountRoutingTypeInvalidForAU,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should equal bsb",
                        Source = "beneficiary.bank_details.account_routing_type1"
                    }
                }
            };

            //***
            var accountRoutingTypeNullForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountRoutingTypeNullForAU.beneficiary.bank_details.account_routing_type1 = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "AU Account Routing Type Null",
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
            var accountRoutingTypeEmptyForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountRoutingTypeEmptyForAU.beneficiary.bank_details.account_routing_type1 = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "AU Account Routing Type Empty",
                    Payload = accountRoutingTypeEmptyForAU,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_routing_type1"
                    }
                }
            };

            //***
            var accountRoutingTypeValueLessThan6CharForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountRoutingTypeValueLessThan6CharForAU.beneficiary.bank_details.account_routing_value1 = "12345";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "AU Account Routing Type Value Less Than 6 Char",
                    Payload = accountRoutingTypeValueLessThan6CharForAU,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should be 6 characters",
                        Source = "beneficiary.bank_details.account_routing_value1"
                    }
                }
            };

            //***
            var accountRoutingTypeValueGreaterThan6CharForAU = GetDefaultCreateBeneficiaryAustraliaPayload();
            accountRoutingTypeValueGreaterThan6CharForAU.beneficiary.bank_details.account_routing_value1 = "1234567";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "AU Account Routing Type Value Greater Than 6 Char",
                    Payload = accountRoutingTypeValueGreaterThan6CharForAU,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should be 6 characters",
                        Source = "beneficiary.bank_details.account_routing_value1"
                    }
                }
            };
        }
    }
}