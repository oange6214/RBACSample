using RBACSample.ViewModels;

namespace RBACSample.Presentations.Views.Pages;

public partial class RegisterView : UserControl
{
    public RegisterView(RegisterViewModel viewModel)
    {
        DataContext = viewModel;
        {
            InitializeComponent();
        }
    }
}