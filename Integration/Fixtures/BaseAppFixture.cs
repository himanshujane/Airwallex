using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tests.Utility;
using static Tests.Helper.General.ConstantHelper;

namespace Tests.Fixtures
{
    /*
     * [Before All Hook]
     * Purpose of this class is to initialize HttpClient and Auth Header object once
     * before running all the tests inside a test class.
     */
    public class BaseAppFixture : IDisposable
    {
        public HttpClient HttpClient { get; }
        public Dictionary<string, string> AuthTokenHeader { get; }

        public BaseAppFixture()
        {
            HttpClient = new HttpClient {BaseAddress = new Uri(EnvironmentFixture.Config.TestUrl)};
            AuthTokenHeader = GetAuthToken().GetAwaiter().GetResult();
        }

        private async Task<Dictionary<string, string>> GetAuthToken()
        {
            var headers = new Dictionary<string, string>
            {
                {HeaderKeyXClientId, EnvironmentFixture.Config.XClientId},
                {HeaderKeyXApi, EnvironmentFixture.Config.XApiKey}
            };
            var response =
                await HttpClient.Post(EndpointUtil.AuthTokenUrl, null, headers: headers);
            var dResponse = await response.DeserializeAuthTokenResponse();

            return new Dictionary<string, string>
            {
                {
                    HeaderKeyAuth,
                    $"Bearer {dResponse.token}"
                }
            };
        }

        /*
         * [After All Hook]
         */
        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}