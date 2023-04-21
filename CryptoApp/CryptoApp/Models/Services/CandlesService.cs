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

        public async Task<List<Candles>> GetCandles(string exchange, string interval, string baseId, string quoteId, long? start = null, long? end = null)
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

            var httpResult = await _httpClient.SendAsync<BaseResponse<List<CandlesResponse>>, GetCandlesRequest>(
                $"{Common.ApiUrl}/candles",
                HttpMethod.Get,
                request);

            if (httpResult == null)
            {
                return new List<Candles>();
            }

            return httpResult.Data?.Select(s => new Candles
            {
                Close = s.Close,
                High = s.High,
                Low = s.Low,
                Open = s.Open,
                Volume = s.Volume,
                Period = DateTime.FromFileTime(s.Period),
            }).ToList() !;
        }
    }
}
