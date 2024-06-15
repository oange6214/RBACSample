using RBACSample.Applications.Services;
using RBACSample.Domains.Dtos;
using RBACSample.Domains.Enums;
using RBACSample.Presentations.Views.Pages;
using RBACSample.Shared.Helpers;
using RBACSample.Views;

namespace RBACSample.ViewModels;

public partial class RegisterViewModel : ObservableObject
{
    private readonly IUserService _userService;

    [ObservableProperty]
    private string _username = default!;

    [ObservableProperty]
    private string _email = default!;

    [ObservableProperty]
    private SecureString _password = default!;

    [ObservableProperty]
    private SecureString _confirmPassword = default!;

    [ObservableProperty]
    private string _infoMessage = default!;

    [ObservableProperty]
    private UserRole _selectedRoleType = default!;

    [ObservableProperty]
    private IEnumerable<UserRole> _roleType = Enum.GetValues(typeof(UserRole)).Cast<UserRole>();

    public RegisterViewModel(IUserService userService)
    {
        _userService = userService;
    }

    [RelayCommand]
    private async Task Register()
    {
        if (Password == null || ConfirmPassword == null || Username == null)
        {
            InfoMessage = "Username and Password cannot be empty.";
            return;
        }

        if (Password.Length == 0 || ConfirmPassword.Length == 0 || string.IsNullOrEmpty(Username))
        {
            InfoMessage = "Username and Password cannot be empty.";
            return;
        }

        if (!PasswordHasher.SSEqual(Password, ConfirmPassword))
        {
            InfoMessage = "Passwords do not match.";
            return;
        }

        var result = await _userService.RegisterUser(new UserDto
        {
            Username = Username,
            Email = Email,
            PasswordHash = Password,
            Role = SelectedRoleType,
        });

        InfoMessage = result ? "Registration successful!" : "UserDto already exists.";
    }

    [RelayCommand]
    private async Task Back()
    {
        WeakReferenceMessenger.Default.Send<string>(nameof(LoginView));
        await Task.CompletedTask;
    }
}