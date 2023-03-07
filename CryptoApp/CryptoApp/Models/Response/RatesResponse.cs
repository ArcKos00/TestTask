namespace CryptoApp.Models.Response
{
    public class RatesResponse
    {
        public string Id { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public string? CurrencySymbol { get; set; }
        public string Type { get; set; } = null!;
        public double RateUsd { get; set; }
    }
}
