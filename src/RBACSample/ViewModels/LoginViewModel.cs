using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using RBACSample.Commons;
using RBACSample.Entities;
using RBACSample.Helper;
using RBACSample.Repository;
using RBACSample.Services;
using RBACSample.Views.Pages;
using System.Security;
using System.Windows.Controls;

namespace RBACSample.ViewModels;

public partial class LoginViewModel : ObservableRecipient
{
    private readonly IServiceProvider _serviceProvider;
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
        IServiceProvider serviceProvider,
        IUserService userService)
    {
        _serviceProvider = serviceProvider;
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

                WeakReferenceMessenger.Default.Send<Page>(_serviceProvider.GetService<DashboardPage>());
            }
        }
        else
        {
            Infomation = "Error login";
        }
    }
}