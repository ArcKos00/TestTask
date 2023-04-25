using CryptoApp.Core.Interfaces;
using CryptoApp.ViewModel.Interfaces;

namespace CryptoApp.Core.Services
{
    public class NavigationService : BaseViewModel, INavigationService
    {
        private readonly Func<Type, BaseViewModel> _viewModelFactory;
        private BaseViewModel _viewModel = null!;

        public NavigationService(Func<Type, BaseViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
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

        public async Task NavigateTo<T, TPreType>(TPreType? id)
            where T : BaseViewModel, IPrefetch<TPreType>
        {
            NavigateTo<T>();
            if (CurrentView is IPrefetch<TPreType> prefetch)
            {
                await prefetch.Prefetch(id!);
            }
        }
    }
}
