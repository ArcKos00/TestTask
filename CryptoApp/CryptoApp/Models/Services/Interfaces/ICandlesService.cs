using CryptoApp.Models.Response;

namespace CryptoApp.Models.Services.Interfaces
{
    public interface ICandlesService
    {
        public Task<List<CandlesResponse>> GetCandles(string exchange, string interval, string baseId, string quoteId, long? start = null, long? end = null);
    }
}
