using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RBACSample.Commons;
using RBACSample.Data;
using RBACSample.Entities;
using RBACSample.Services;
using RBACSample.Views.Pages;
using System.Windows.Controls;

namespace RBACSample.ViewModels;

public partial class LoginViewModel : ObservableRecipient
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IUserRepository _userRepository;

    [ObservableProperty]
    private string _username = string.Empty;

    [ObservableProperty]
    private string _password = string.Empty;

    [ObservableProperty]
    private string _infomation = string.Empty;

    public LoginViewModel(
        IServiceProvider serviceProvider,
        IUserRepository userRepository)
    {
        _serviceProvider = serviceProvider;
        _userRepository = userRepository;
    }

    [RelayCommand]
    private async Task Login()
    {
        var result = await _userRepository.GetUser(new TbLoginrole
        {
            Username = _username,
            PasswordHash = _password
        });

        if (result != null)
        {
            var IsUserType = Enum.TryParse(result.Username.ToUpper(), out UserType userType);

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