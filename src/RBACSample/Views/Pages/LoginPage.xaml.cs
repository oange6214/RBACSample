using RBACSample.ViewModels;
using System.Windows.Controls;

namespace RBACSample.Views;

public partial class LoginPage : Page
{
    public LoginPage(LoginViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}