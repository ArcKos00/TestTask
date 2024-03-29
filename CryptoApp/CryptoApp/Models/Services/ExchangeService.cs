﻿using CryptoApp.Models;
using CryptoApp.Models.Response;
using CryptoApp.Core.Interfaces;
using CryptoApp.Models.Services.Interfaces;

namespace CryptoApp.Models.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IHttpClientService _httpClient;

        public ExchangeService(IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ExchangesResponse>> GetExchanges()
        {
            var result = await _httpClient.SendAsync<BaseResponse<List<ExchangesResponse>>, object>(
                $"{Common.ApiUrl}/exchanges",
                HttpMethod.Get,
                null);

            if (result == null)
            {
                return new List<ExchangesResponse>();
            }

            return result.Data!;
        }

        public async Task<ExchangesResponse> GetExchanges(string id)
        {
            var result = await _httpClient.SendAsync<BaseResponse<ExchangesResponse>, object>(
                $"{Common.ApiUrl}/exchanges/{id}",
                HttpMethod.Get,
                null);

            if (result == null)
            {
                return new ExchangesResponse();
            }

            return result.Data!;
        }
    }
}
