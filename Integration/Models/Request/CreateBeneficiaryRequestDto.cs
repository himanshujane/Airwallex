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
        public dynamic nickname { get; set; }
        public dynamic payer_entity_type { get; set; }
        public List<string> payment_methods { get; set; }
    }

    public class BeneficiaryDetailsDto
    {
        public BeneficiaryAdditionalInfoDto additional_info { get; set; }
        public BeneficiaryAddressDto address { get; set; }
        public BeneficiaryBankDetailsDto bank_details { get; set; }
        public dynamic company_name { get; set; }
        public dynamic entity_type { get; set; }
    }

    public class BeneficiaryAdditionalInfoDto
    {
        public dynamic personal_email { get; set; }
    }

    public class BeneficiaryAddressDto
    {
        public dynamic city { get; set; }
        public dynamic country_code { get; set; }
        public dynamic postcode { get; set; }
        public dynamic state { get; set; }
        public dynamic street_address { get; set; }
    }

    public class BeneficiaryBankDetailsDto
    {
        public dynamic account_currency { get; set; }
        public dynamic account_name { get; set; }
        public dynamic account_number { get; set; }
        public dynamic account_routing_type1 { get; set; }
        public dynamic account_routing_value1 { get; set; }
        public dynamic bank_country_code { get; set; }
        public dynamic bank_name { get; set; }
        public dynamic swift_code { get; set; }
    }
}