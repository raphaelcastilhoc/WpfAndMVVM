using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using WpfAndMVVM.Infrastructure;
using WpfAndMVVM.Repositories;
using WpfAndMVVM.ViewModels;
using WpfAndMVVM.Views;

namespace WpfAndMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }

        public static ServiceProvider DIContainer { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();

                    services.AddTransient<MainViewModel>();
                    services.AddTransient<HomeViewModel>();
                    services.AddTransient<GameViewModel>();

                    services.AddTransient<GameRepository>();

                    services.AddDbContext<GamingDbContext>(options =>
                    {
                        options.UseSqlite("Data Source = Gaming.db");
                    });
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            base.OnExit(e);
        }
    }
}
