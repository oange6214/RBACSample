using RBACSample.ViewModels;
using System.Windows.Controls;

namespace RBACSample.Views.Pages;

public partial class DashboardPage : Page
{
    public DashboardPage(DashboardViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}