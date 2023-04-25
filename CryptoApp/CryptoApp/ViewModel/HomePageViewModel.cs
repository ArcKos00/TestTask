using CryptoApp.Core;
using CryptoApp.Core.Interfaces;
using CryptoApp.Models;
using CryptoApp.Models.Response;
using CryptoApp.Models.Services.Interfaces;
using CryptoApp.ViewModel.Interfaces;

namespace CryptoApp.ViewModel
{
    public class HomePageViewModel : BaseViewModel, IPrefetch<object>
    {
        private readonly INavigationService _navigationService;
        private readonly IAssetsService _assetsService;
        private List<AssetsResponse> _mainCoins = new List<AssetsResponse>();
        private PaginationInfo _paginationInfo = new PaginationInfo();

        public HomePageViewModel(IAssetsService assetsService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _assetsService = assetsService;
            GoToCoin = new RelayCommand(o => _navigationService.NavigateTo<CoinPageViewModel, string>((string)o), o => true);
            SwapPage = new RelayCommand(o => Swap(o), o => true);
        }

        public List<AssetsResponse> MainCoins
        {
            get
            {
                return _mainCoins
                    .Skip(ItemsOnPage * _paginationInfo.PageIndex)
                    .Take(ItemsOnPage)
                    .ToList();
            }
            private set
            {
                if (!MainCoins.Equals(value))
                {
                    _mainCoins = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ItemsOnPage
        {
            get => _paginationInfo.ItemsOnPage;
            init => _paginationInfo.ItemsOnPage = value;
        }

        public int PageIndex
        {
            get => _paginationInfo.PageIndex + 1;
            set
            {
                if (value >= 0 && value < 10)
                {
                    _paginationInfo.PageIndex = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(MainCoins));
                }
            }
        }

        public int TotalPages
        {
            get => _paginationInfo.TotalPages;
            set
            {
                _paginationInfo.TotalPages = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand GoToCoin { get; set; }

        public RelayCommand SwapPage { get; set; }

        public async Task Prefetch(object obj)
        {
            var expectedList = await _assetsService.GetAssets();

            PageIndex = 0;
            TotalPages = (int)Math.Ceiling((double)(expectedList.Count / ItemsOnPage));

            MainCoins = new List<AssetsResponse>(expectedList);
        }

        public void Swap(object obj)
        {
            PageIndex = _paginationInfo.PageIndex + int.Parse((string)obj);
        }
    }
}