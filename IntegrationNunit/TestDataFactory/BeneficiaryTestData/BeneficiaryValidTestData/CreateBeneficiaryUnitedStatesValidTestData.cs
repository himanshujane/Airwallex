using System.Collections;
using NunitTests.Models.Request;
using static NunitTests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData.CreateBeneficiaryCommonValidTestData;

namespace NunitTests.TestDataFactory.BeneficiaryTestData.BeneficiaryValidTestData
{
    public class CreateBeneficiaryUnitedStatesValidTestData : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            /*
             * This test data verifies
             * Account Number Length is 1 Char
             * Account_routing_type1 as ABA
             * Account_routing_value1 Length is 9 Char
             */
            var accountNumberLengthIs1ForUS = GetDefaultCreateBeneficiaryPayload();
            accountNumberLengthIs1ForUS.beneficiary.bank_details.account_number = "1";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "US Account Number Length is 1",
                    Payload = accountNumberLengthIs1ForUS
                }
            };

            //***
            var accountNumberLengthIs9ForUS = GetDefaultCreateBeneficiaryPayload();
            accountNumberLengthIs9ForUS.beneficiary.bank_details.account_number = "123456789";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "US Account Number Length is 9",
                    Payload = accountNumberLengthIs9ForUS
                }
            };

            //***
            var accountNumberLengthIs17ForUS = GetDefaultCreateBeneficiaryPayload();
            accountNumberLengthIs17ForUS.beneficiary.bank_details.account_number = "12345678912345678";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "US Account Number Length is 17",
                    Payload = accountNumberLengthIs17ForUS
                }
            };


            //***
            var swiftCodeLenghtIs11 = GetDefaultCreateBeneficiaryPayload();
            swiftCodeLenghtIs11.beneficiary.bank_details.swift_code = "FTSBUS33SFI";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "US Swift Code Length is 11",
                    Payload = swiftCodeLenghtIs11
                }
            };


            //***
            var accountRoutingTypeAbaForUS = GetDefaultCreateBeneficiaryPayload();
            accountRoutingTypeAbaForUS.beneficiary.bank_details.account_routing_type1 = "aba";
            accountRoutingTypeAbaForUS.beneficiary.bank_details.account_routing_value1 = "123456789";
            yield return new CreateBeneficiaryRequestDto[]
            {
                new()
                {
                    TestcaseName = "US Account Routing Type as aba and value is 9 Char Long",
                    Payload = accountRoutingTypeAbaForUS
                }
            };
        }
    }
}