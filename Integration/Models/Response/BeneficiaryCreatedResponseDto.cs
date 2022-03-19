using System.Collections.Generic;

namespace Tests.Models.Response
{
    
    public class BeneficiaryCreatedResponseDto
    {
        public BeneficiaryCreatedDetailsDto beneficiary { get; set; }
        public string beneficiary_id { get; set; }
        public string nickname { get; set; }
        public string payer_entity_type { get; set; }
        public List<string> payment_methods { get; set; }
    }

    public class BeneficiaryCreatedDetailsDto
    {
        public BeneficiaryCreatedAdditionalInfoDto additional_info { get; set; }
        public BeneficiaryCreatedAddressDto address { get; set; }
        public BeneficiaryCreatedBankDetailsDto bank_details { get; set; }
        public string company_name { get; set; }
        public string entity_type { get; set; }
    }

    public class BeneficiaryCreatedAdditionalInfoDto
    {
        public string personal_email { get; set; }
    }

    public class BeneficiaryCreatedAddressDto
    {
        public string city { get; set; }
        public string country_code { get; set; }
        public string postcode { get; set; }
        public string state { get; set; }
        public string street_address { get; set; }
    }

    public class BeneficiaryCreatedBankDetailsDto
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