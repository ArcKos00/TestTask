using CryptoApp.Models.Response;

namespace CryptoApp.Services.Interfaces
{
    public interface IAssetsService
    {
        public Task<List<AssetsResponse>> GetAssets(string search = null!, string ids = null!, int? limit = null, int? offset = null);
        public Task<AssetsResponse> GetAsset(string id);
        public Task<HistoryResponse> GetAssetHistory(string id, string interval, long? start = null, long? end = null!);
        public Task<MarketsResponse> GetAssetMarkets(string id, int? limit, double? offset);
    }
}
