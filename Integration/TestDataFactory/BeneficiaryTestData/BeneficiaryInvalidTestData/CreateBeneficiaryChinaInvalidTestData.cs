using System.Collections.Generic;
using System.Reflection;
using Tests.Models.Request;
using Xunit.Sdk;
using static Tests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData.CreateBeneficiaryChinaValidTestData;

namespace Tests.TestDataFactory.BeneficiaryTestData.BeneficiaryInvalidTestData
{
    public class CreateBeneficiaryChinaInvalidTestData : DataAttribute
    {
        public override IEnumerable<CreateBeneficiaryRequestDto[]> GetData(MethodInfo testMethod)
        {
            //***
            var accountNumberGreaterThan34ForCN = GetDefaultCreateBeneficiaryChinaPayload();
            accountNumberGreaterThan34ForCN.beneficiary.bank_details.account_number =
                "12345678901234567890123456789012345";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "CN Account Number Greater Than 34",
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
            var accountNumberLessThan8ForCN = GetDefaultCreateBeneficiaryChinaPayload();
            accountNumberLessThan8ForCN.beneficiary.bank_details.account_number = "1234567";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    _TestName = "CN Account Number Less Than 8",
                    Payload = accountNumberLessThan8ForCN,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should contain 8 to 34 characters",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };
        }
    }
}