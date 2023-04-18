using CryptoApp.Core;
using CryptoApp.Core.Interfaces;

namespace CryptoApp.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        public MainWindowViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToHome = new RelayCommand(o => Navigation.NavigateTo<HomePageViewModel>(), o => true);
            NavigateToBABA = new RelayCommand(o => Navigation.NavigateTo<CoinPageViewModel>("bitcoin"), o => true);
        }

        public INavigationService Navigation
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToHome { get; set; }
        public RelayCommand NavigateToBABA { get; set; }
    }
}
