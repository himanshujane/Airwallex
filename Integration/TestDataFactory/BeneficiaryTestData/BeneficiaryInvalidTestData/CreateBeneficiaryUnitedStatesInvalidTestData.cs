using System.Collections.Generic;
using System.Reflection;
using Tests.Models.Request;
using Xunit.Sdk;
using static Tests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData.CreateBeneficiaryCommonValidTestData;

namespace Tests.TestDataFactory.BeneficiaryTestData.BeneficiaryInvalidTestData
{
    public class CreateBeneficiaryUnitedStatesInvalidTestData : DataAttribute
    {
        public override IEnumerable<CreateBeneficiaryRequestDto[]> GetData(MethodInfo testMethod)
        {
            //***
            var accountNumberGreaterThan17ForUS = GetDefaultCreateBeneficiaryPayload();
            accountNumberGreaterThan17ForUS.beneficiary.bank_details.account_number = "123456789123456789";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "US Account Number Greater Than 17",
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
            var accountNumberEmptyForUS = GetDefaultCreateBeneficiaryPayload();
            accountNumberEmptyForUS.beneficiary.bank_details.account_number = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "US Account Number Empty",
                    Payload = accountNumberEmptyForUS,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountNumberNullForUS = GetDefaultCreateBeneficiaryPayload();
            accountNumberNullForUS.beneficiary.bank_details.account_number = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "US Account Number Null",
                    Payload = accountNumberNullForUS,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountRoutingTypeInvalidForUS = GetDefaultCreateBeneficiaryPayload();
            accountRoutingTypeInvalidForUS.beneficiary.bank_details.account_routing_type1 = "bsb";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "US Account Routing Type Invalid [bsb]",
                    Payload = accountRoutingTypeInvalidForUS,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should equal aba",
                        Source = "beneficiary.bank_details.account_routing_type1"
                    }
                }
            };

            //***
            var accountRoutingTypeNullForUS = GetDefaultCreateBeneficiaryPayload();
            accountRoutingTypeNullForUS.beneficiary.bank_details.account_routing_type1 = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "US Account Routing Type Null",
                    Payload = accountRoutingTypeNullForUS,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_routing_type1"
                    }
                }
            };

            //***
            var accountRoutingTypeEmptyForUS = GetDefaultCreateBeneficiaryPayload();
            accountRoutingTypeEmptyForUS.beneficiary.bank_details.account_routing_type1 = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "US Account Routing Type Empty",
                    Payload = accountRoutingTypeEmptyForUS,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_routing_type1"
                    }
                }
            };

            //***
            var accountRoutingTypeValueLessThan9CharForUS = GetDefaultCreateBeneficiaryPayload();
            accountRoutingTypeValueLessThan9CharForUS.beneficiary.bank_details.account_routing_value1 = "12345678";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "US Account Routing Type Value Less Than 9 Char",
                    Payload = accountRoutingTypeValueLessThan9CharForUS,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should be 9 characters long",
                        Source = "beneficiary.bank_details.account_routing_value1"
                    }
                }
            };

            //***
            var accountRoutingTypeValueGreaterThan9CharForUS = GetDefaultCreateBeneficiaryPayload();
            accountRoutingTypeValueGreaterThan9CharForUS.beneficiary.bank_details.account_routing_value1 = "1234567890";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "US Account Routing Type Value Greater Than 9 Char",
                    Payload = accountRoutingTypeValueGreaterThan9CharForUS,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should be 9 characters long",
                        Source = "beneficiary.bank_details.account_routing_value1"
                    }
                }
            };
        }
    }
}