using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NunitTests.Models.Response;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace NunitTests.Utility
{
    public static class JsonUtil
    {
        private static readonly JsonSerializerOptions Options = new()
            {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

        public static async Task<BeneficiaryCreatedResponseDto> DeserializeCreateBeneficiary(
            this HttpResponseMessage res)
        {
            var resString = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<BeneficiaryCreatedResponseDto>(resString, Options);
        }

        public static async Task<ErrorResponseDto> DeserializeErrorResponse(
            this HttpResponseMessage res)
        {
            var resString = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ErrorResponseDto>(resString, Options);
        }

        public static async Task<AuthTokenResponseDto> DeserializeAuthTokenResponse(
            this HttpResponseMessage res)
        {
            var resString = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AuthTokenResponseDto>(resString, Options);
        }


        public static HttpContent ConvertToHttpContent(object requestData)
        {
            var formatting = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            return new StringContent(
                JsonConvert.SerializeObject(requestData, formatting),
                Encoding.Default,
                "application/json");
        }
        
        //Deserialize XML Response
        // public static async Task<DataResponseDto> DeserializeData(this HttpResponseMessage res)
        // {
        //     var resString = await res.Content.ReadAsStringAsync();
        //     var reader = new StringReader(resString);
        //     var serializer = new XmlSerializer(typeof(DataResponseDto));
        //     var dResponse = (DataResponseDto) serializer.Deserialize(reader);
        //     return dResponse;
        // }
    }
}