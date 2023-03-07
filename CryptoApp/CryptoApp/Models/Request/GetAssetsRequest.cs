namespace CryptoApp.Models.Request
{
    public class GetAssetsRequest
    {
        public string Search { get; set; } = null!;
        public string Ids { get; set; } = null!;
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }
}
