using CryptoApp.Core;
using CryptoApp.Core.Interfaces;
using CryptoApp.Models;

namespace CryptoApp.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private string _searchFor = string.Empty;

        public MainWindowViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToHome = new RelayCommand(o => _navigationService.NavigateTo<HomePageViewModel, object>(default), o => true);
            Search = new RelayCommand(Searchs, o => true);
        }

        public INavigationService Navigation
        {
            get => _navigationService;
            init
            {
                _navigationService = value;
            }
        }

        public string SearchString
        {
            get => _searchFor;
            set
            {
                _searchFor = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToHome { get; set; }
        public RelayCommand Search { get; set; }

        private void Searchs(object obj)
        {
            _navigationService.NavigateTo<SearchViewModel, string>(SearchString);
            SearchString = string.Empty;
        }
    }
}
