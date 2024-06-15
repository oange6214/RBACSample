using RBACSample.Presentations.Views.Pages;

namespace RBACSample.ViewModels;

public partial class MainWindowViewModel : ObservableRecipient
{
    [ObservableProperty]
    private ContentControl _currentPage;

    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        CurrentPage = serviceProvider.GetService<LoginView>();

        WeakReferenceMessenger.Default.Register<string>(
            typeof(MainWindowViewModel),
            (recipient, page) =>
        {
            switch (page)
            {
                case nameof(LoginView):
                    CurrentPage = serviceProvider.GetRequiredService<LoginView>();
                    break;

                case nameof(DashboardView):
                    CurrentPage = serviceProvider.GetRequiredService<DashboardView>();
                    break;

                case nameof(RegisterView):
                    CurrentPage = serviceProvider.GetRequiredService<RegisterView>();
                    break;
            }
        });
    }
}