using RBACSample.Presentations.Views;
using RBACSample.ViewModels;

namespace RBACSample;

public partial class MainWindow : Window, IWindow
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}