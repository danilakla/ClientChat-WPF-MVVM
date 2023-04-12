using ClientChat_WPF_MVVM.View;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM.Services;
public class NavigationService : INavigationService
{
    private readonly IHost _host;
    private readonly ConfirmEmailViewModel _confirmEmailViewModel;

    public NavigationService(IHost host, ConfirmEmailViewModel confirmEmailViewModel)
    {
        _host = host;
        _confirmEmailViewModel = confirmEmailViewModel;
    }
    public void NavigateToChatView()
    {
        var currentWindow = _host.Services.GetRequiredService<ChatView>();
        var context = _host.Services.GetRequiredService<ChatNavigationViewModel>();
        currentWindow.DataContext = context;
        currentWindow.Show();
        Application.Current.MainWindow.Owner = currentWindow;
        Application.Current.MainWindow.Close();
    }

    public void NavigateToConfirmEmailView()
    {
        var data = _host.Services.GetRequiredService<NavigationPreviewViewModel>();
        data.SelectedViewModel= _confirmEmailViewModel;
        
    }
}
