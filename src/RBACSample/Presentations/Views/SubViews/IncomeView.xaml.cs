using RBACSample.Presentations.ViewModels;

namespace RBACSample.Views.SubViews;

public partial class IncomeView : UserControl
{
    public IncomeView(IncomeViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}