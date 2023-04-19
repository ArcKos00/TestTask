using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CryptoApp.Core;
using CryptoApp.Core.Interfaces;
using CryptoApp.Models.Response;
using CryptoApp.Models.Services.Interfaces;

namespace CryptoApp.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IAssetsService _assetsService;
        private ObservableCollection<AssetsResponse> _mainCoins = new ();

        public HomePageViewModel(IAssetsService assetsService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _assetsService = assetsService;
            FillStartMenu();
            _mainCoins.CollectionChanged += (object? sender, NotifyCollectionChangedEventArgs e) => OnPropertyChanged();
        }

        public ObservableCollection<AssetsResponse> MainCoins
        {
            get => _mainCoins;
            private set
            {
                if (!MainCoins.Equals(value))
                {
                    _mainCoins = value;
                    OnPropertyChanged();
                }
            }
        }

        public int CountCoins { get; init; } = 10;

        private async void FillStartMenu()
        {
            var expectedList = await _assetsService.GetAssets();
            MainCoins = new ObservableCollection<AssetsResponse>(expectedList
                .Take(CountCoins)
                .ToList());
        }
    }
}
