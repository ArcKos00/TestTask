using CryptoApp.Models;
using CryptoApp.Models.Request;
using CryptoApp.Models.Response;
using CryptoApp.Core.Interfaces;
using CryptoApp.Models.Services.Interfaces;

namespace CryptoApp.Models.Services
{
    public class MarketService : IMarketService
    {
        private readonly IHttpClientService _httpClient;
        public MarketService(IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MarketsResponse>> GetMarkets(
            string? exchangeId,
            string? baseId,
            string? baseSymbol,
            string? quoteId,
            string? quoteSymbol,
            string? assetId,
            string? assetSymbol,
            int? limit,
            double? offset)
        {
            var result = await _httpClient.SendAsync<BaseResponse<List<MarketsResponse>>, GetMarketsRequest>(
                $"{Common.ApiUrl}/markets",
                HttpMethod.Get,
                new GetMarketsRequest
                {
                    ExchangeId = exchangeId,
                    BaseSymbol = baseSymbol,
                    QuoteSymbol = quoteSymbol,
                    BaseId = baseId,
                    AssetSymbol = assetSymbol,
                    QuoteId = quoteId,
                    AssetId = assetId,
                    Limit = limit,
                    Offset = offset
                });

            if (result == null)
            {
                return new List<MarketsResponse>();
            }

            return result.Data!;
        }
    }
}
