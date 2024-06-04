using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RBACSample.Commons;
using RBACSample.Services;
using RBACSample.Views.Pages;
using System.Security;

namespace RBACSample.ViewModels;

public partial class LoginViewModel : ObservableRecipient
{
    private readonly IUserService _userService;

    [ObservableProperty]
    private string _infomation = string.Empty;

    [ObservableProperty]
    private string _password = string.Empty;

    [ObservableProperty]
    private SecureString _securePassword;

    [ObservableProperty]
    private string _username = string.Empty;

    public LoginViewModel(
        IUserService userService)
    {
        _userService = userService;
    }

    [RelayCommand]
    private async Task Login()
    {
        var isValidUser = await _userService.VerifyUser(_username, _securePassword);

        if (isValidUser)
        {
            var IsUserType = Enum.TryParse(_username.ToUpper(), out UserType userType);

            if (IsUserType)
            {
                UserInfo.UserType = userType;

                WeakReferenceMessenger.Default.Send<string>(nameof(DashboardPage));
            }
        }
        else
        {
            Infomation = "Error login";
        }
    }

    [RelayCommand]
    private async Task CreateUser()
    {
        WeakReferenceMessenger.Default.Send<string>(nameof(RegisterPage));
    }
}