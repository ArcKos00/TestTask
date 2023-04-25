using CryptoApp.Core;
using CryptoApp.Core.Interfaces;
using CryptoApp.Models.Response;
using CryptoApp.Models.Services.Interfaces;
using CryptoApp.ViewModel.Interfaces;

namespace CryptoApp.ViewModel
{
    public class SearchViewModel : BaseViewModel, IPrefetch<string>
    {
        private readonly IAssetsService _assetsService;
        private readonly INavigationService _navigationService;
        private AssetsResponse _selected = null!;
        private List<AssetsResponse> _searchResult = null!;

        public SearchViewModel(IAssetsService assetsService, INavigationService navigationService)
        {
            _assetsService = assetsService;
            _navigationService = navigationService;
        }

        public List<AssetsResponse> SearchResult
        {
            get => _searchResult;
            set
            {
                _searchResult = value;
                OnPropertyChanged();
            }
        }

        public AssetsResponse Select
        {
            get => _selected;
            set
            {
                _selected = value;
                _navigationService.NavigateTo<CoinPageViewModel, string>(Select.Id);
            }
        }

        public async Task Prefetch(string search)
        {
            var result = await _assetsService.GetAssets(search: search);
            SearchResult = result
                .Where(w => (w.Name.ToUpper().Contains(search.ToUpper())
                            || w.Id.ToUpper().Contains(search.ToUpper())
                            || w.Symbol.ToUpper().Contains(search.ToUpper())))
                .ToList();
        }
    }
}
