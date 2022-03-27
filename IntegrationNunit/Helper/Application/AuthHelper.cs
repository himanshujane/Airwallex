using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NunitTests.Fixtures;
using NunitTests.Utility;
using static NunitTests.Helper.General.ConstantHelper;

namespace NunitTests.Helper.Application
{
    public class AuthHelper
    {
        private readonly HttpClient _httpClient;

        public AuthHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Dictionary<string, string>> GetAuthToken()
        {
            var headers = new Dictionary<string, string>
            {
                {HeaderKeyXClientId, EnvironmentFixture.Config.XClientId},
                {HeaderKeyXApi, EnvironmentFixture.Config.XApiKey}
            };
            var response =
                await _httpClient.Post(EndpointUtil.AuthTokenUrl, null, headers: headers);
            var dResponse = await response.DeserializeAuthTokenResponse();

            return new Dictionary<string, string>
            {
                {
                    HeaderKeyAuth,
                    $"Bearer {dResponse.token}"
                }
            };
        }
    }
}