using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient _client;
        public CustomHttpClient()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetStringAsync(string uri,
            string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            if (authorizationToken != null)
            {
                //Do this after token service
            }

            var response = await _client.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<HttpResponseMessage> PostAsync<EventItem>(string uri, EventItem item,
            string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            if (authorizationToken != null)
            {

            }

            var response = await _client.PostAsync(uri, stringContent);
            return response;
        }

        public Task<HttpResponseMessage> PutAsync<T>(string uri, T item, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> DeleteAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            throw new NotImplementedException();
        }
    }
}
