namespace CryptoApp.Models.Request
{
    public class GetAssetsMarketsRequest
    {
        public int? Limit { get; set; } = null!;
        public double? Offset { get; set; } = null!;
    }
}
