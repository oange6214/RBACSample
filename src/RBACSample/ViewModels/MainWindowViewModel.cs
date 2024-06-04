using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using RBACSample.Views;
using RBACSample.Views.Pages;
using System.Windows.Controls;

namespace RBACSample.ViewModels;

public partial class MainWindowViewModel : ObservableRecipient
{
    [ObservableProperty]
    private Page _currentPage;

    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        CurrentPage = serviceProvider.GetService<LoginPage>();

        WeakReferenceMessenger.Default.Register<string>(typeof(MainWindowViewModel), (recipient, page) =>
        {
            switch (page)
            {
                case nameof(LoginPage):
                    CurrentPage = serviceProvider.GetRequiredService<LoginPage>();
                    break;

                case nameof(DashboardPage):
                    CurrentPage = serviceProvider.GetRequiredService<DashboardPage>();
                    break;

                case nameof(RegisterPage):
                    CurrentPage = serviceProvider.GetRequiredService<RegisterPage>();
                    break;
            }
        });
    }
}