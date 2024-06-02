using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RBACSample.Data;
using RBACSample.Models;
using RBACSample.Repository;
using RBACSample.ViewModels;
using RBACSample.Views;
using RBACSample.Views.Pages;
using System.Windows;

namespace RBACSample;

public partial class App : Application
{
    private IHost _host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                // Configuration
                var config = new ConfigurationBuilder()
                    .AddUserSecrets<AppConfig>()
                    .Build();

                // Database and repository
                services.AddNpgsql<RoleDbContext>(config["ConnectionStrings:Role_DB"]);
                services.AddSingleton<IUserRepository, UserRepository>();

                // Register view model
                services.AddSingleton<DashboardViewModel>();
                services.AddSingleton<LoginViewModel>();
                services.AddSingleton<MainWindowViewModel>();

                // Register view
                services.AddSingleton<DashboardPage>();
                services.AddSingleton<LoginPage>();

                services.AddSingleton<IWindow, MainWindow>();
            })
            .Build();

    public App()
    {
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();

        _host.Dispose();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        _host.Services.GetRequiredService<IWindow>().Show();
    }
}