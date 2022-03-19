using System.Collections.Generic;

namespace Tests.Models.Request
{
    public class CreateBeneficiaryRequestDto : BaseRequestDto
    {
        public CreateBeneficiaryPayloadDto Payload { get; set; }
    }

    public class CreateBeneficiaryPayloadDto
    {
      
        public BeneficiaryDetailsDto beneficiary { get; set; }
        public string nickname { get; set; }
        public string payer_entity_type { get; set; }
        public List<string> payment_methods { get; set; }
    }

    public class BeneficiaryDetailsDto
    {
        public BeneficiaryAdditionalInfoDto additional_info { get; set; }
        public BeneficiaryAddressDto address { get; set; }
        public BeneficiaryBankDetailsDto bank_details { get; set; }
        public string company_name { get; set; }
        public string entity_type { get; set; }
    }

    public class BeneficiaryAdditionalInfoDto
    {
        public string personal_email { get; set; }
    }

    public class BeneficiaryAddressDto
    {
        public string city { get; set; }
        public string country_code { get; set; }
        public string postcode { get; set; }
        public string state { get; set; }
        public string street_address { get; set; }
    }

    public class BeneficiaryBankDetailsDto
    {
        public string account_currency { get; set; }
        public string account_name { get; set; }
        public string account_number { get; set; }
        public string account_routing_type1 { get; set; }
        public string bank_country_code { get; set; }
        public string bank_name { get; set; }
        public string swift_code { get; set; }
    }
}