using RBACSample.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace RBACSample.Views.Pages;

public partial class RegisterPage : Page
{
    public RegisterPage(RegisterViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();

        // 使用 PasswordBox 的 PasswordChanged 事件來綁定 SecureString
        PasswordBox.PasswordChanged += OnPasswordChanged;
        ConfirmPasswordBox.PasswordChanged += OnConfirmPasswordChanged;
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is RegisterViewModel viewModel)
        {
            viewModel.Password = ((PasswordBox)sender).SecurePassword;
        }
    }

    private void OnConfirmPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is RegisterViewModel viewModel)
        {
            viewModel.ConfirmPassword = ((PasswordBox)sender).SecurePassword;
        }
    }
}