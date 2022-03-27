using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace NunitTests.Utility
{
    public static class HttpUtil
    {
        public static async Task<HttpResponseMessage> Post(this HttpClient client, string uri, HttpContent requestData,
            Dictionary<string, string> headers)
        {
            client.DefaultRequestHeaders.Clear();
            foreach (var (key, value) in headers)
            {
                client.DefaultRequestHeaders.Add(key, value);
            }

            var response = await client.PostAsync(uri, requestData);
            return response;
        }

        public static async Task<HttpResponseMessage> Put(this HttpClient client, string uri, HttpContent requestData,
            Dictionary<string, string> headers)
        {
            client.DefaultRequestHeaders.Clear();
            foreach (var (key, value) in headers)
            {
                client.DefaultRequestHeaders.Add(key, value);
            }

            var response = await client.PutAsync(uri, requestData);
            return response;
        }

        public static async Task<HttpResponseMessage> Patch(this HttpClient client, string uri,
            HttpContent requestData,
            Dictionary<string, string> headers)
        {
            client.DefaultRequestHeaders.Clear();
            foreach (var (key, value) in headers)
            {
                client.DefaultRequestHeaders.Add(key, value);
            }

            var response = await client.PatchAsync(uri, requestData);
            return response;
        }

        public static async Task<HttpResponseMessage> Get(this HttpClient client, string uri,
            Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var (key, value) in headers)
                {
                    client.DefaultRequestHeaders.Add(key, value);
                }
            }

            var response = await client.GetAsync(uri);
            return response;
        }

        public static string HttpContentToString(HttpContent response)
        {
            var output = response.ReadAsStream();
            var reader = new StreamReader(output);
            return reader.ReadToEnd();
        }
    }
}