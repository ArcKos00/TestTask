using CryptoApp.Core.Interfaces;
using CryptoApp.ViewModel.Interfaces;
using CryptoApp.ViewModel;

namespace CryptoApp.Core.Services
{
    public class NavigationService : BaseViewModel, INavigationService
    {
        private readonly Func<Type, BaseViewModel> _viewModelFactory;
        private BaseViewModel _viewModel = null!;

        public NavigationService(Func<Type, BaseViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            NavigateTo<HomePageViewModel>();
        }

        public BaseViewModel CurrentView
        {
            get
            {
                return _viewModel;
            }
            private set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        public void NavigateTo<T>()
            where T : BaseViewModel
        {
            var viewModel = _viewModelFactory.Invoke(typeof(T));
            CurrentView = viewModel;
        }

        public async Task NavigateTo<T>(string id)
            where T : BaseViewModel, IPrefetch
        {
            NavigateTo<T>();
            if (CurrentView is IPrefetch prefetch)
            {
                await prefetch.Prefetch(id);
            }
        }
    }
}
