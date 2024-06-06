using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RBACSample.Helper;
using RBACSample.Services;
using RBACSample.Views.SubViews;
using System.Windows.Controls;

namespace RBACSample.ViewModels;

public partial class DashboardViewModel : ObservableRecipient
{
    private readonly IUserSessionService _userSessionService;
    private readonly IAuthorizationService _authorizationService;

    [ObservableProperty]
    private ContentControl _currentView;

    public DashboardViewModel(
        IUserSessionService userSessionService,
        IAuthorizationService authorizationService
        )
    {
        _userSessionService = userSessionService;
        _authorizationService = authorizationService;

        CurrentView = new IncomeView(null);
    }

    private bool IsAuthorization(string resource)
    {
        var user = _userSessionService.GetCurrentUser();

        var authorized = _authorizationService.AuthorizeUser(user.Name, resource)
                                                  .AwaitByPushFrame();

        return authorized;
    }

    [RelayCommand(CanExecute = nameof(IsAuthorization))]
    private async Task Income(string resource)
    {
    }

    [RelayCommand(CanExecute = nameof(IsAuthorization))]
    private async Task Expense(string resource)
    {
    }

    [RelayCommand(CanExecute = nameof(IsAuthorization))]
    private async Task Report(string resource)
    {
    }

    [RelayCommand(CanExecute = nameof(IsAuthorization))]
    private async Task Client(string resource)
    {
    }

    [RelayCommand(CanExecute = nameof(IsAuthorization))]
    private async Task Invoice(string resource)
    {
    }

    [RelayCommand(CanExecute = nameof(IsAuthorization))]
    private async Task Labour(string resource)
    {
    }
}