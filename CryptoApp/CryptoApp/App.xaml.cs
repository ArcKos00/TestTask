using System.IO;
using CryptoApp.ViewModel;
using CryptoApp.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CryptoApp.Core;
using CryptoApp.Core.Interfaces;
using CryptoApp.Models.Services.Interfaces;
using CryptoApp.Models.Services;
using CryptoApp.Core.Services;
using Microsoft.Extensions.Configuration;

namespace CryptoApp
{
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            var config = GetConfigure();

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

                    services.AddSingleton<INavigationService, NavigationService>();
                    services.AddSingleton<Func<Type, BaseViewModel>>(serviceProvider => viewModelType => (BaseViewModel)serviceProvider.GetRequiredService(viewModelType));

                    services.AddTransient<MainWindowViewModel>();
                    services.AddTransient<CoinPageViewModel>();
                    services.AddTransient<SearchViewModel>();
                    services.AddTransient(provider =>
                        new HomePageViewModel(provider.GetRequiredService<IAssetsService>(), provider.GetRequiredService<INavigationService>())
                        {
                            ItemsOnPage = config.GetValue<int>("CountItemsOnPage")
                        });

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
            await _host.Services.GetRequiredService<INavigationService>().NavigateTo<HomePageViewModel, object>(default);
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

        private IConfiguration GetConfigure()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
