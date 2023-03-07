namespace CryptoApp.Models.Request
{
    public class GetAssetsHistoryRequest
    {
        [Required]
        public string Interval { get; set; } = null!;
        public long? Start { get; set; } = null!;
        public long? End { get; set; } = null!;
    }
}
