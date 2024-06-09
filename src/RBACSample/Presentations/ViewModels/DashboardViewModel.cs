using RBACSample.Applications.Services;
using RBACSample.Domains.Dtos;
using RBACSample.Shared.Helpers;
using RBACSample.Views.SubViews;

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

        CurrentView = new IncomeView(null!);
    }

    private bool IsAuthorization(string resource)
    {
        var user = _userSessionService.GetCurrentUser();

        UserResouceDto newUser = new()
        {
            Username = user.Username,
            Resouce = resource
        };

        var authorized = _authorizationService.AuthorizeUser(newUser)
                                                  .AwaitByPushFrame();

        return authorized;
    }

    [RelayCommand(CanExecute = nameof(IsAuthorization))]
    private async Task Income(string resource)
    {
        await Task.CompletedTask;
    }

    [RelayCommand(CanExecute = nameof(IsAuthorization))]
    private async Task Expense(string resource)
    {
        await Task.CompletedTask;
    }

    [RelayCommand(CanExecute = nameof(IsAuthorization))]
    private async Task Report(string resource)
    {
        await Task.CompletedTask;
    }

    [RelayCommand(CanExecute = nameof(IsAuthorization))]
    private async Task Client(string resource)
    {
        await Task.CompletedTask;
    }

    [RelayCommand(CanExecute = nameof(IsAuthorization))]
    private async Task Invoice(string resource)
    {
        await Task.CompletedTask;
    }

    [RelayCommand(CanExecute = nameof(IsAuthorization))]
    private async Task Labour(string resource)
    {
        await Task.CompletedTask;
    }
}