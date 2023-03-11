using ClientChat_WPF_MVVM.Strore;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ClientChat_WPF_MVVM.ViewModel;
public class MainViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private readonly NavigationWindowStore _navigationWindowStore;

    public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    public Window CurrentWinodw => _navigationWindowStore.CurrentWindow;
    HubConnection Connection;
    public MainViewModel(NavigationStore navigationStore, NavigationWindowStore navigationWindowStore)
    {
    

        _navigationWindowStore = navigationWindowStore;
        _navigationStore = navigationStore;

        _navigationWindowStore.CurrentWindowChanged += OnCurrentWindowChanged;

        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    private void OnCurrentViewModelChanged()
    {


        OnPropertyChanged(nameof(CurrentViewModel));
    }

    private void OnCurrentWindowChanged()
    {
        CurrentWinodw.Cursor = new System.Windows.Input.Cursor(Application.GetResourceStream(new Uri(@"../CustomUI/Circle.cur", UriKind.Relative)).Stream);

        CurrentWinodw.Show();
        CurrentWinodw.DataContext = CurrentViewModel;
        Application.Current.MainWindow.Owner = CurrentWinodw;
        Application.Current.MainWindow.Close();

    }
}
