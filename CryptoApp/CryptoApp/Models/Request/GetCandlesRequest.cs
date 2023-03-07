namespace CryptoApp.Models.Request
{
    public class GetCandlesRequest
    {
        [Required]
        public string Exchange { get; set; } = null!;
        [Required]
        public string Interval { get; set; } = null!;
        [Required]
        public string BaseId { get; set; } = null!;
        [Required]
        public string QuoteId { get; set; } = null!;
        public long? Start { get; set; }
        public long? End { get; set; }
    }
}
