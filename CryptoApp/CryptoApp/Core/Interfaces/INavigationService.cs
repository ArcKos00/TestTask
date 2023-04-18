using CryptoApp.ViewModel.Interfaces;

namespace CryptoApp.Core.Interfaces
{
    public interface INavigationService
    {
        BaseViewModel CurrentView { get; }
        void NavigateTo<T>()
            where T : BaseViewModel;
        Task NavigateTo<T>(string id)
            where T : BaseViewModel, IPrefetch;
    }
}
