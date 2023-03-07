﻿using CryptoApp.Models;
using CryptoApp.Models.Request;
using CryptoApp.Models.Response;
using CryptoApp.Services.Interfaces;
using Infrastructure;
using Infrastructure.Services.Interfaces;

namespace CryptoApp.Services
{
    public class CandlesService : ICandlesService
    {
        private readonly IHttpClientService _httpClient;

        public CandlesService(IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CandlesResponse>> GetCandles(string exchange, string interval, string baseId, string quoteId, long? start, long? end)
        {
            var request = new GetCandlesRequest
            {
                Exchange = exchange,
                Interval = interval,
                BaseId = baseId
            };

            if ((start != null && end != null) ||
                (start == null && end == null))
            {
                request.Start = start;
                request.End = end;
            }

            var result = await _httpClient.SendAsync<BaseResponse<List<CandlesResponse>>, GetCandlesRequest>(
                $"{Common.ApiUrl}/candles",
                HttpMethod.Get,
                request);

            if (result == null)
            {
                return new List<CandlesResponse>();
            }

            return result.Data!;
        }
    }
}
