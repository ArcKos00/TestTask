namespace CryptoApp.Models.Response
{
    public class MarketsResponse : BaseMarketResponse
    {
        public string Rank { get; set; } = null!;
        public double PriceQuote { get; set; }
        public double PercentExchangeVolume { get; set; }
        public int? TradesCount24Hr { get; set; }
        public long Updated { get; set; }
    }
}
