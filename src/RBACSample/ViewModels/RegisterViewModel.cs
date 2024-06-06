using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RBACSample.Enums;
using RBACSample.Helper;
using RBACSample.Models;
using RBACSample.Services;
using RBACSample.Views;
using System.Security;

namespace RBACSample.ViewModels;

public partial class RegisterViewModel : ObservableObject
{
    private readonly IUserService _userService;

    [ObservableProperty]
    private string _username;

    [ObservableProperty]
    private SecureString _password;

    [ObservableProperty]
    private SecureString _confirmPassword;

    [ObservableProperty]
    private string _infoMessage;

    public RegisterViewModel(IUserService userService)
    {
        _userService = userService;
    }

    [RelayCommand]
    private async Task Register()
    {
        if (_password == null || _confirmPassword == null || _username == null)
        {
            InfoMessage = "Username and Password cannot be empty.";
            return;
        }

        if (_password.Length == 0 || _confirmPassword.Length == 0 || string.IsNullOrEmpty(_username))
        {
            InfoMessage = "Username and Password cannot be empty.";
            return;
        }

        if (!PasswordHasher.SSEqual(_password, _confirmPassword))
        {
            InfoMessage = "Passwords do not match.";
            return;
        }

        var result = await _userService.RegisterUser(new User
        {
            Name = _username,
            Password = _password,
            Role = UserRole.OPERATOR
        });

        InfoMessage = result ? "Registration successful!" : "User already exists.";
    }

    [RelayCommand]
    private async Task Back()
    {
        WeakReferenceMessenger.Default.Send<string>(nameof(LoginPage));
    }
}