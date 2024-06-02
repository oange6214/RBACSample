using CommunityToolkit.Mvvm.ComponentModel;
using RBACSample.Commons;

namespace RBACSample.ViewModels;

public partial class DashboardViewModel : ObservableRecipient
{
    private IServiceProvider _serviceProvider;

    [ObservableProperty]
    private uint _permissionLevel = 0;

    public DashboardViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        var permissionLevel = (uint)UserInfo.UserType;

        PermissionLevel = permissionLevel;
    }
}