namespace CryptoApp.Models.Request
{
    public class GetAssetsMarketsRequest : GetIdRequest
    {
        public int? Limit { get; set; } = null!;
        public double? Offset { get; set; } = null!;
    }
}
