using RBACSample.ViewModels;
using RBACSample.Views;
using System.Windows;

namespace RBACSample;

public partial class MainWindow : Window, IWindow
{
    public MainWindow(
        MainWindowViewModel viewModel
        )
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }

    public MainWindowViewModel ViewModel { get; set; }
}