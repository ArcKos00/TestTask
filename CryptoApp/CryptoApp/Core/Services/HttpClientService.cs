﻿using CryptoApp.Core.Interfaces;

namespace CryptoApp.Core.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _httpClient;

        public HttpClientService(IHttpClientFactory client)
        {
            _httpClient = client;
        }

        public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest? content)
        {
            var client = _httpClient.CreateClient();

            var httpMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = method
            };

            if (content != null)
            {
                httpMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }

            var result = await client.SendAsync(httpMessage);

            if (result.IsSuccessStatusCode)
            {
                var resultContent = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
                return response!;
            }

            return default!;
        }
    }
}
