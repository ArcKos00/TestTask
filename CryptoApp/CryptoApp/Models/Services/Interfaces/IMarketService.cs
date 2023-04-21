using CryptoApp.Models.Response;

namespace CryptoApp.Models.Services.Interfaces
{
    public interface IMarketService
    {
        public Task<List<MarketsResponse>> GetMarkets(string? exchangeId = null, string? baseId = null, string? baseSymbol = null, string? quoteId = null, string? quoteSymbol = null, string? assetId = null, string? assetSymbol = null, int? limit = null, double? offset = null);
    }
}
