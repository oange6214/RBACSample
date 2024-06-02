using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using RBACSample.Views;
using System.Windows.Controls;

namespace RBACSample.ViewModels;

public partial class MainWindowViewModel : ObservableRecipient
{
    [ObservableProperty]
    private Page _currentPage;

    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        CurrentPage = serviceProvider.GetService<LoginPage>();

        WeakReferenceMessenger.Default.Register<Page>(typeof(MainWindowViewModel), (recipient, page) =>
        {
            CurrentPage = page;
        });
    }
}