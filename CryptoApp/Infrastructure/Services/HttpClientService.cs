﻿using Infrastructure.Services.Interfaces;

namespace CryptoApp.Services
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
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer XXXX");

            var httpMessage = new HttpRequestMessage();
            httpMessage.RequestUri = new Uri(url);
            httpMessage.Method = method;

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

            return default(TResponse) !;
        }
    }
}