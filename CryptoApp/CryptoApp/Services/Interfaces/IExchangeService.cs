using CryptoApp.Models.Response;

namespace CryptoApp.Services.Interfaces
{
    public interface IExchangeService
    {
        public Task<List<ExchangesResponse>> GetExchanges();
        public Task<List<ExchangesResponse>> GetExchanges(string id);
    }
}
