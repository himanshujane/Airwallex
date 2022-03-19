using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tests.Utility;
using static Tests.Helper.General.ConstantHelper;

namespace Tests.Fixtures
{
    public class BaseAppFixture : IDisposable
    {
        public BaseAppFixture()
        {
            HttpClient = new HttpClient {BaseAddress = new Uri(EnvironmentFixture.Config.TestUrl)};
            AuthToken = GetAuthToken().GetAwaiter().GetResult();
        }

        public HttpClient HttpClient { get; }

        public string AuthToken { get; }

        private async Task<string> GetAuthToken()
        {
            var headers = new Dictionary<string, string>
            {
                {HeaderKeyXClientId, EnvironmentFixture.Config.XClientId},
                {HeaderKeyXApi, EnvironmentFixture.Config.XApiKey}
            };
            var response =
                await HttpClient.Post(EndpointUtil.AuthTokenUrl, null, headers: headers);
            var dResponse = await response.DeserializeAuthTokenResponse();

            return dResponse.token;
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}