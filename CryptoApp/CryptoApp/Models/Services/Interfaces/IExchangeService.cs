using CryptoApp.Models.Response;

namespace CryptoApp.Models.Services.Interfaces
{
    public interface IExchangeService
    {
        public Task<List<ExchangesResponse>> GetExchanges();
        public Task<ExchangesResponse> GetExchanges(string id);
    }
}
