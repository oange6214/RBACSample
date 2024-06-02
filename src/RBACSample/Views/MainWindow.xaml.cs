using RBACSample.ViewModels;
using RBACSample.Views;
using System.Windows;

namespace RBACSample;

public partial class MainWindow : Window, IWindow
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}