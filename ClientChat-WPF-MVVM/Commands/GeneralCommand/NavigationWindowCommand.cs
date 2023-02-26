using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.ViewModel;
using System.Windows;

public class NavigationWindowCommand<TView, TViewModel> : CommandBase where TView : Window
                                                           where TViewModel : ViewModelBase
{
    private readonly NavigationWindowService<TView> _navigationWindowService;
    private readonly NavigationService<TViewModel> _navigationService;


    public NavigationWindowCommand(NavigationWindowService<TView> navigationWindowService, NavigationService<TViewModel> navigationService)
    {
        _navigationWindowService = navigationWindowService;
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        _navigationService.Navigate();
        _navigationWindowService.Navigate();

    }
}