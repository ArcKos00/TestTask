namespace CryptoApp.Models.Response
{
    public class AssetsResponse
    {
        public string Id { get; set; } = null!;
        public int Rank { get; set; }
        public string Symbol { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Supply { get; set; }
        public double? MaxSupply { get; set; }
        public double MarketCaoUsd { get; set; }
        public double VolumeUsd24Hr { get; set; }
        public double PriceUsd { get; set; }
        public double? ChangePercent24Hr { get; set; }
        public double? Vwap24Hr { get; set; }
    }
}
