using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.ViewModel;

public class NavigateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
{
    private readonly NavigationService<TViewModel> _navigationService;

    public NavigateCommand(NavigationService<TViewModel> navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        _navigationService.Navigate();
    }
}
