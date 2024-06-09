using RBACSample.ViewModels;

namespace RBACSample.Views;

public partial class LoginPage : Page
{
    public LoginPage(LoginViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (this.DataContext != null)
        {
            ((dynamic)this.DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword;
        }
    }
}