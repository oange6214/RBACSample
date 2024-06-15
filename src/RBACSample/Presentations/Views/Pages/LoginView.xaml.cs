using RBACSample.ViewModels;

namespace RBACSample.Presentations.Views.Pages;

public partial class LoginView : UserControl
{
    public LoginView(LoginViewModel viewModel)
    {
        DataContext = viewModel;
        {
            InitializeComponent();
        }
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (this.DataContext != null)
        {
            ((dynamic)this.DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword;
        }
    }
}