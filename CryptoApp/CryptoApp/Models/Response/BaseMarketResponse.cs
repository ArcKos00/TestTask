namespace CryptoApp.Models.Response
{
    public class BaseMarketResponse
    {
        public string ExchangeId { get; set; } = null!;
        public string BaseId { get; set; } = null!;
        public string QuoteId { get; set; } = null!;
        public string BaseSymbol { get; set; } = null!;
        public string QuoteSymbol { get; set; } = null!;
        public double VolumeUsd24Hr { get; set; }
        public double PriceUsd { get; set; }
    }
}
