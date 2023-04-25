namespace CryptoApp.ViewModel.Interfaces
{
    public interface IPrefetch<T>
    {
        Task Prefetch(T id);
    }
}
