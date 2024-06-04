using CommunityToolkit.Mvvm.ComponentModel;
using RBACSample.Commons;

namespace RBACSample.ViewModels;

public partial class DashboardViewModel : ObservableRecipient
{
    [ObservableProperty]
    private uint _permissionLevel = 0;

    public DashboardViewModel()
    {
        var permissionLevel = (uint)UserInfo.UserType;

        PermissionLevel = permissionLevel;
    }
}