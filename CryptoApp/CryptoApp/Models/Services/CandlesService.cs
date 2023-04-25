using CryptoApp.Models;
using CryptoApp.Models.Request;
using CryptoApp.Models.Response;
using CryptoApp.Core.Interfaces;
using CryptoApp.Models.Services.Interfaces;

namespace CryptoApp.Models.Services
{
    public class CandlesService : ICandlesService
    {
        private readonly IHttpClientService _httpClient;

        public CandlesService(IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CandlesResponse>> GetCandles(string exchange, string interval, string baseId, string quoteId, long? start = null, long? end = null)
        {
            var request = new GetCandlesRequest
            {
                Exchange = exchange,
                Interval = interval,
                BaseId = baseId,
                QuoteId = quoteId
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

            return result.Data !;
        }
    }
}
