using CryptoApp.Core;
using CryptoApp.Core.Interfaces;
using CryptoApp.Models;

namespace CryptoApp.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ILangService _langService;
        private string _searchFor = string.Empty;

        public MainWindowViewModel(INavigationService navigationService, ILangService langService)
        {
            _navigationService = navigationService;
            _langService = langService;
            NavigateToHome = new RelayCommand(o => _navigationService.NavigateTo<HomePageViewModel, object>(default), o => true);
            Search = new RelayCommand(Searchs, o => true);
            _langService.SetLanguage("en");
        }

        public INavigationService Navigation
        {
            get => _navigationService;
            init
            {
                _navigationService = value;
            }
        }

        public Language Lang
        {
            get => _langService.Lang;
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
