using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RBACSample.ViewModels;
using RBACSample.Views;
using System.Windows;

namespace RBACSample;

public partial class App : Application
{
    private IHost _host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, serviceCollection) =>
            {
                serviceCollection.AddSingleton<MainWindowViewModel>();
                serviceCollection.AddSingleton<IWindow, MainWindow>();
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