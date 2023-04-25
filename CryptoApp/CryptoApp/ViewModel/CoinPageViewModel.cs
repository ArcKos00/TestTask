using CryptoApp.Core;
using CryptoApp.Models.Response;
using CryptoApp.Models.Services.Interfaces;
using CryptoApp.ViewModel.Interfaces;

namespace CryptoApp.ViewModel
{
    public class CoinPageViewModel : BaseViewModel, IPrefetch<string>
    {
        private readonly IAssetsService _assetsService;
        private AssetsResponse _asset = null!;
        private AssetMarketResponse _selectedMarket = null!;
        private List<AssetMarketResponse> _markets = new ();
        private string _marketName = string.Empty;
        public CoinPageViewModel(IAssetsService assetService)
        {
            _assetsService = assetService;
            Sort = new RelayCommand(o => SortWith(o), o => true);
        }

        public RelayCommand Sort { get; set; }

        public AssetsResponse Coin
        {
            get => _asset;
            private set
            {
                _asset = value;
                OnPropertyChanged();
            }
        }

        public AssetMarketResponse Market
        {
            get => _selectedMarket;
            set
            {
                _selectedMarket = value;
                OnPropertyChanged();
            }
        }

        public List<AssetMarketResponse> Markets
        {
            get
            {
                if (string.IsNullOrEmpty(_marketName))
                {
                    return _markets;
                }

                return _markets
                    .Where(w => w.ExchangeId
                        .ToUpper()
                        .Contains(MarketName.ToUpper()))
                    .ToList();
            }
            set
            {
                _markets = value;
                OnPropertyChanged();
            }
        }

        public string MarketName
        {
            get => _marketName;
            set
            {
                _marketName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Markets));
            }
        }

        public async Task Prefetch(string id)
        {
            Coin = await _assetsService.GetAsset(id);
            Markets = await _assetsService.GetAssetMarkets(id);
            Market = Markets[0];
        }

        private void SortWith(object param)
        {
            switch ((string)param)
            {
                case "Price":
                    _markets.Sort((m1, m2) => m2.PriceUsd.CompareTo(m1.PriceUsd));
                    break;
                case "ExchangeId":
                    _markets.Sort((m1, m2) => m1.ExchangeId.CompareTo(m2.ExchangeId));
                    break;
            }

            Markets = new List<AssetMarketResponse>(_markets);
        }
    }
}
