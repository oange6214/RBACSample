using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RBACSample.Enums;
using RBACSample.Models;
using RBACSample.Services;
using RBACSample.Views.Pages;
using System.Security;

namespace RBACSample.ViewModels;

public partial class LoginViewModel : ObservableRecipient
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserService _userService;
    private readonly IUserSessionService _userSessionService;

    [ObservableProperty]
    private string _infomation = string.Empty;

    [ObservableProperty]
    private string _password = string.Empty;

    [ObservableProperty]
    private SecureString _securePassword;

    [ObservableProperty]
    private string _username = string.Empty;

    public LoginViewModel(
        IAuthenticationService authenticationService,
        IUserService userService,
        IUserSessionService userSessionService
        )
    {
        _userService = userService;
        _authenticationService = authenticationService;
        _userSessionService = userSessionService;
    }

    [RelayCommand]
    private async Task Login()
    {
        var isValidUser = await _authenticationService.VerifyUser(_username, _securePassword);

        if (isValidUser)
        {
            var IsUserType = Enum.TryParse(_username.ToUpper(), out UserRole userType);

            if (IsUserType)
            {
                _userSessionService.SetCurrentUser(new User
                {
                    Name = Username,
                    Role = userType
                });

                WeakReferenceMessenger.Default.Send<string>(nameof(DashboardPage));
            }
        }
        else
        {
            Infomation = $"[Login Failed] Invalid username or password. ";
        }
    }

    [RelayCommand]
    private async Task CreateUser()
    {
        WeakReferenceMessenger.Default.Send<string>(nameof(RegisterPage));
    }
}