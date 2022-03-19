using System;
using System.Net.Http;

namespace Tests.Fixtures
{
    public class BaseAppFixture : IDisposable
    {
        public BaseAppFixture()
        {
            HttpClient = new HttpClient
                {BaseAddress = new Uri(EnvironmentFixture.GetEnvironment.TestUrl)};
        }

        public HttpClient HttpClient { get; }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}