using CryptoApp.Models.Response;

namespace CryptoApp.Services.Interfaces
{
    public interface IRatesService
    {
        public Task<List<RatesResponse>> GetRates();
        public Task<RatesResponse> GetRate(string id);
    }
}
