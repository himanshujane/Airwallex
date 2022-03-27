using System.Collections;
using NunitTests.Models.Request;
using static
    NunitTests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData.CreateBeneficiaryChinaValidTestData;

namespace NunitTests.TestDataFactory.BeneficiaryTestData.BeneficiaryInvalidTestData
{
    public class CreateBeneficiaryChinaInvalidTestData : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            //***
            var accountNumberGreaterThan34ForCN = GetDefaultCreateBeneficiaryChinaPayload();
            accountNumberGreaterThan34ForCN.beneficiary.bank_details.account_number =
                "12345678901234567890123456789012345";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "CN Account Number Greater Than 34",
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
                    TestcaseName = "CN Account Number Less Than 8",
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
            var accountNumberHaveSpecialCharForCN = GetDefaultCreateBeneficiaryChinaPayload();
            accountNumberHaveSpecialCharForCN.beneficiary.bank_details.account_number = "1234@678";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "CN Account Number Have Special Char",
                    Payload = accountNumberHaveSpecialCharForCN,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should contain alphanumeric characters only",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountNumberNullForCN = GetDefaultCreateBeneficiaryChinaPayload();
            accountNumberNullForCN.beneficiary.bank_details.account_number = null;
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "CN Account Number Null",
                    Payload = accountNumberNullForCN,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountNumberEmptyForCN = GetDefaultCreateBeneficiaryChinaPayload();
            accountNumberEmptyForCN.beneficiary.bank_details.account_number = "";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "CN Account Number Empty",
                    Payload = accountNumberEmptyForCN,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "This field is required",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };

            //***
            var accountNumberHaveSpaceForCN = GetDefaultCreateBeneficiaryChinaPayload();
            accountNumberHaveSpaceForCN.beneficiary.bank_details.account_number = " ";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "CN Account Number Have Space",
                    Payload = accountNumberHaveSpaceForCN,
                    Expected = new
                    {
                        Code = "payment_schema_validation_failed",
                        Message = "Should contain alphanumeric characters only",
                        Source = "beneficiary.bank_details.account_number"
                    }
                }
            };
        }
    }
}