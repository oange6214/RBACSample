using RBACSample.Applications.Services;
using RBACSample.Domains.Dtos;
using RBACSample.Domains.Enums;
using RBACSample.Views.Pages;

namespace RBACSample.ViewModels;

public partial class LoginViewModel : ObservableRecipient
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserService _userService;
    private readonly IUserSessionService _userSessionService;

    [ObservableProperty]
    private string _infomation = default!;

    [ObservableProperty]
    private string _password = default!;

    [ObservableProperty]
    private SecureString _securePassword = default!;

    [ObservableProperty]
    private string _username = default!;

    public LoginViewModel(
        IAuthenticationService authenticationService,
        IUserService userService,
        IUserSessionService userSessionService)
    {
        _authenticationService = authenticationService;
        _userService = userService;
        _userSessionService = userSessionService;
    }

    [RelayCommand]
    private async Task Login()
    {
        var isValidUser = await _authenticationService.VerifyUser(new UserDto
        {
            Username = Username,
            PasswordHash = SecurePassword
        });

        if (isValidUser)
        {
            var IsUserType = Enum.TryParse(Username.ToUpper(), out UserRole userType);

            if (IsUserType)
            {
                _userSessionService.SetCurrentUser(new UserDto
                {
                    Username = Username,
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
        await Task.CompletedTask;
    }
}