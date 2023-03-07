namespace CryptoApp.Models
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public long Timestamp { get; set; }
    }
}
