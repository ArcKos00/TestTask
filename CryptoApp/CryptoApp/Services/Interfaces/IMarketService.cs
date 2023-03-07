using CryptoApp.Models.Response;

namespace CryptoApp.Services.Interfaces
{
    public interface IMarketService
    {
        public Task<List<MarketsResponse>> GetMarkets(string? exchangeId, string? baseId, string? baseSymbol, string? quoteId, string? quoteSymbol, string? assetId, string? assetSymbol, int? limit, double? offset);
    }
}
