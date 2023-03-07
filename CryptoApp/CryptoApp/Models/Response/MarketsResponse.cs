namespace CryptoApp.Models.Response
{
    public class MarketsResponse
    {
        public string ExchangeId { get; set; } = null!;
        public string Rank { get; set; } = null!;
        public string BaseSymbol { get; set; } = null!;
        public string BaseId { get; set; } = null!;
        public string QuoteSymbol { get; set; } = null!;
        public string QuoteId { get; set; } = null!;
        public double PriceQuote { get; set; }
        public double PriceUsd { get; set; }
        public double VolumeUsd24Hr { get; set; }
        public double PercentExchangeVolume { get; set; }
        public int TradesCount24Hr { get; set; }
        public long Updated { get; set; }
    }
}
