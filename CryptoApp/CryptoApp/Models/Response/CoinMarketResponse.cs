namespace CryptoApp.Models.Response
{
    public class CoinMarketResponse
    {
        public string ExchangeId { get; set; } = null!;
        public string BaskeId { get; set; } = null!;
        public string QuoteId { get; set; } = null!;
        public string BaseSymbol { get; set; } = null!;
        public string QuoteSymbol { get; set; } = null!;
        public double VolumeUsd24Hr { get; set; }
        public double PriceUsd { get; set; }
        public double VolumePercent { get; set; }
    }
}
