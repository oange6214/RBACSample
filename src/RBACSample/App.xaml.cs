using RBACSample.Applications.Services;
using RBACSample.Domains.Models;
using RBACSample.Infrastructures.Data;
using RBACSample.Infrastructures.Repository;
using RBACSample.Presentations.ViewModels;
using RBACSample.Presentations.Views;
using RBACSample.ViewModels;
using RBACSample.Views;
using RBACSample.Views.Pages;
using RBACSample.Views.SubViews;

namespace RBACSample;

public partial class App : Application
{
    private IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                ConfigureServices(services);
            })
            .Build();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Configuration
        var config = new ConfigurationBuilder()
            .AddUserSecrets<AppConfig>()
            .Build();

        // DbContext
        services.AddDbContext<RoleDbContext>(
            options => options.UseNpgsql(config["ConnectionStrings:Role_DB"]));

        //Add repositories and services with appropriate lifetimes
        services.AddTransient<IAuthorizationService, AuthorizationService>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IUserSessionService, UserSessionService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        //Register view model
        services.AddScoped<IncomeViewModel>();

        services.AddScoped<RegisterViewModel>();
        services.AddScoped<DashboardViewModel>();
        services.AddScoped<LoginViewModel>();

        services.AddScoped<MainWindowViewModel>();

        // Register view
        services.AddScoped<IncomeView>();

        // Register page
        services.AddScoped<RegisterPage>();
        services.AddScoped<DashboardPage>();
        services.AddScoped<LoginPage>();

        services.AddScoped<IWindow, MainWindow>();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        _host.Services.GetRequiredService<IWindow>().Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync(TimeSpan.FromSeconds(3));

        _host.Dispose();

        base.OnExit(e);
    }
}