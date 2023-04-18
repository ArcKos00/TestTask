using CryptoApp.ViewModel;
using CryptoApp.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CryptoApp.Core;
using CryptoApp.Core.Interfaces;
using CryptoApp.Models.Services.Interfaces;
using CryptoApp.Models.Services;
using CryptoApp.Core.Services;

namespace CryptoApp
{
    public partial class App : Application
    {
        private readonly int _countItemsOnHomePage = 10;
        private readonly IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddHttpClient();
                    services.AddTransient<IAssetsService, AssetsService>();
                    services.AddTransient<ICandlesService, CandlesService>();
                    services.AddTransient<IExchangeService, ExchangeService>();
                    services.AddTransient<IMarketService, MarketService>();
                    services.AddTransient<IRatesService, RatesService>();
                    services.AddTransient<IHttpClientService, HttpClientService>();

                    services.AddTransient(provider => new HomePageViewModel(provider.GetRequiredService<IAssetsService>())
                    {
                        CountCoins = _countItemsOnHomePage
                    });
                    services.AddTransient<MainWindowViewModel>();
                    services.AddTransient<CoinPageViewModel>();

                    services.AddSingleton<INavigationService, NavigationService>();

                    services.AddSingleton<Func<Type, BaseViewModel>>(serviceProvider => viewModelType => (BaseViewModel)serviceProvider.GetRequiredService(viewModelType));

                    services.AddSingleton(provider => new MainWindow
                    {
                        DataContext = provider.GetRequiredService<MainWindowViewModel>()
                    });
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            _host.Services.GetRequiredService<INavigationService>().NavigateTo<HomePageViewModel>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }

            base.OnExit(e);
        }
    }
}
