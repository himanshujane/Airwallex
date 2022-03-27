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
    }
}