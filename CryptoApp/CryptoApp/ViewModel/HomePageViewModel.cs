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
        private readonly IAssetsService _assetsService;
        private ObservableCollection<AssetsResponse> _mainCoins = new ObservableCollection<AssetsResponse>();

        public HomePageViewModel(IAssetsService assetsService)
        {
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

        public int CountCoins { get; init; }

        private async void FillStartMenu()
        {
            var expectedList = await _assetsService.GetAssets();
            MainCoins = new ObservableCollection<AssetsResponse>(expectedList
                .Take(CountCoins)
                .ToList());
        }
    }
}
