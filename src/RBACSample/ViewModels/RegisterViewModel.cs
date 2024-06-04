using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RBACSample.Services;
using RBACSample.Views;
using System.Runtime.InteropServices;
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

        if (!SecureStringEqual(_password, _confirmPassword))
        {
            InfoMessage = "Passwords do not match.";
            return;
        }

        var result = await _userService.RegisterUser(_username, _password);

        InfoMessage = result ? "Registration successful!" : "User already exists.";
    }

    [RelayCommand]
    private async Task Back()
    {
        WeakReferenceMessenger.Default.Send<string>(nameof(LoginPage));
    }

    private bool SecureStringEqual(SecureString a, SecureString b)
    {
        if (a.Length != b.Length)
            return false;

        var ptrA = Marshal.SecureStringToBSTR(a);
        var ptrB = Marshal.SecureStringToBSTR(b);

        try
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (Marshal.ReadByte(ptrA, i) != Marshal.ReadByte(ptrB, i))
                    return false;
            }
        }
        finally
        {
            Marshal.ZeroFreeBSTR(ptrA);
            Marshal.ZeroFreeBSTR(ptrB);
        }

        return true;
    }
}