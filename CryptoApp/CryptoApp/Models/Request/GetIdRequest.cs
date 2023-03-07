namespace CryptoApp.Models.Request
{
    public class GetIdRequest
    {
        [Required]
        public string Id { get; set; } = null!;
    }
}
