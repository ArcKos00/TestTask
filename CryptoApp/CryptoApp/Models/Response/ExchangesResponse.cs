namespace CryptoApp.Models.Response
{
    public class ExchangesResponse
    {
        public string ExchangeId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Rank { get; set; }
        public decimal? PercentTotalVolume { get; set; }
        public double? VolumeUsd { get; set; }
        public int TradingPairs { get; set; }
        public bool? Socket { get; set; }
        public string ExchangeUrl { get; set; } = null!;
        public long Updated { get; set; }
    }
}
