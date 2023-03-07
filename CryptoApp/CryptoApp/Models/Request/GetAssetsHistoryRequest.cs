namespace CryptoApp.Models.Request
{
    public class GetAssetsHistoryRequest : GetIdRequest
    {
        [Required]
        public string Interval { get; set; } = null!;
        public long? Start { get; set; } = null!;
        public long? End { get; set; } = null!;
    }
}
