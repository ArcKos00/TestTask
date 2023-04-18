using CryptoApp.Models;
using CryptoApp.Models.Request;
using CryptoApp.Models.Response;
using CryptoApp.Core.Interfaces;
using CryptoApp.Models.Services.Interfaces;

namespace CryptoApp.Models.Services
{
    public class AssetsService : IAssetsService
    {
        private readonly IHttpClientService _httpClient;
        public AssetsService(IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AssetsResponse>> GetAssets(string? search = null, string? ids = null, int? limit = null, int? offset = null)
        {
            var result = await _httpClient.SendAsync<BaseResponse<List<AssetsResponse>>, GetAssetsRequest>(
                $"{Common.ApiUrl}/assets",
                HttpMethod.Get,
                new GetAssetsRequest
                {
                    Search = search,
                    Ids = ids,
                    Limit = limit,
                    Offset = offset
                });

            if (result == null)
            {
                return new List<AssetsResponse>();
            }

            return result.Data!;
        }

        public async Task<AssetsResponse> GetAsset(string id)
        {
            var result = await _httpClient.SendAsync<BaseResponse<AssetsResponse>, object>(
                $"{Common.ApiUrl}/assets/{id}",
                HttpMethod.Get,
                null);

            if (result == null)
            {
                return new AssetsResponse();
            }

            return result.Data!;
        }

        public async Task<HistoryResponse> GetAssetHistory(string id, string interval, long? start = null, long? end = null!)
        {
            var request = new GetAssetsHistoryRequest
            {
                Interval = interval
            };

            if ((start != null && end != null) ||
                (start == null && end == null))
            {
                request.Start = start;
                request.End = end;
            }

            var result = await _httpClient.SendAsync<BaseResponse<HistoryResponse>, GetAssetsHistoryRequest>(
                $"{Common.ApiUrl}/assets/{id}/",
                HttpMethod.Get,
                request);

            if (result == null)
            {
                return new HistoryResponse();
            }

            return result.Data!;
        }

        public async Task<List<AssetMarketResponse>> GetAssetMarkets(string id, int? limit, double? offset)
        {
            var request = new GetAssetsMarketsRequest();

            if ((limit != null && offset != null) ||
                (limit == null && offset == null))
            {
                request.Limit = limit;
                request.Offset = offset;
            }

            var result = await _httpClient.SendAsync<BaseResponse<List<AssetMarketResponse>>, GetAssetsMarketsRequest>(
                $"{Common.ApiUrl}/assets/{id}/markets",
                HttpMethod.Get,
                request);

            if (result == null)
            {
                return new List<AssetMarketResponse>();
            }

            return result.Data!;
        }
    }
}
