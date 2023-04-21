using CryptoApp.Core;
using CryptoApp.Models.Response;
using CryptoApp.Models.Services.Interfaces;
using CryptoApp.ViewModel.Interfaces;

namespace CryptoApp.ViewModel
{
    public class CoinPageViewModel : BaseViewModel, IPrefetch
    {
        private readonly IAssetsService _assetsService;
        private AssetsResponse _asset = null!;
        public CoinPageViewModel(IAssetsService assetService)
        {
            _assetsService = assetService;
        }

        public AssetsResponse Coin
        {
            get => _asset;
            private set
            {
                _asset = value;
                OnPropertyChanged();
            }
        }

        public async Task Prefetch(string id)
        {
            Coin = await _assetsService.GetAsset(id);
        }
    }
}
