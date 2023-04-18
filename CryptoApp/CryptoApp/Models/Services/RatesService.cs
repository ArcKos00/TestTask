using CryptoApp.Models;
using CryptoApp.Models.Response;
using CryptoApp.Core.Interfaces;
using CryptoApp.Models.Services.Interfaces;

namespace CryptoApp.Models.Services
{
    public class RatesService : IRatesService
    {
        private readonly IHttpClientService _httpClient;

        public RatesService(IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RatesResponse>> GetRates()
        {
            var result = await _httpClient.SendAsync<BaseResponse<List<RatesResponse>>, object>(
                $"{Common.ApiUrl}/rates",
                HttpMethod.Get,
                null);
            if (result == null)
            {
                return new List<RatesResponse>();
            }

            return result.Data!;
        }

        public async Task<RatesResponse> GetRate(string id)
        {
            var result = await _httpClient.SendAsync<BaseResponse<RatesResponse>, object>(
                $"{Common.ApiUrl}/rates/{id}",
                HttpMethod.Get,
                null);
            if (result == null)
            {
                return new RatesResponse();
            }

            return result.Data!;
        }
    }
}
