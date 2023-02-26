using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM.Strore;

public class NavigationWindowStore
{
    private Window _currentWindow;
    public Window CurrentWindow
    {
        get => _currentWindow;
        set
        {
            _currentWindow = value;
            OnCurrentViewModelChanged();
        }
    }

    public event Action CurrentWindowChanged;

    private void OnCurrentViewModelChanged()
    {
        CurrentWindowChanged?.Invoke();
    }
}