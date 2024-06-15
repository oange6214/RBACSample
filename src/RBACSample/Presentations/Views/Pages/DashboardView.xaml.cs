using RBACSample.ViewModels;

namespace RBACSample.Presentations.Views.Pages;

public partial class DashboardView : UserControl
{
    public DashboardView(DashboardViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}