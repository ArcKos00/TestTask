namespace CryptoApp.Models.Request
{
    public class GetMarketsRequest
    {
        public string? ExchangeId { get; set; } = null!;
        public string? BaseSymbol { get; set; } = null!;
        public string? QuoteSymbol { get; set; } = null!;
        public string? BaseId { get; set; } = null!;
        public string? QuoteId { get; set; } = null!;
        public string? AssetSymbol { get; set; } = null!;
        public string? AssetId { get; set; } = null!;
        public int? Limit { get; set; } = null!;
        public double? Offset { get; set; } = null!;
    }
}
