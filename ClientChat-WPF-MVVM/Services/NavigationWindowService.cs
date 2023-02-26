using ClientChat_WPF_MVVM.Strore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM.Services;
public class NavigationWindowService<TView> where TView : Window
{
    private readonly NavigationWindowStore _navigationStore;
    private readonly Func<TView> _createView;

    public NavigationWindowService(NavigationWindowStore navigationWindowStore, Func<TView> createView)
    {
        _navigationStore = navigationWindowStore;
        _createView = createView;
    }

    public void Navigate()
    {
        _navigationStore.CurrentWindow = _createView();
    }
    public Window GetCurrentWindow()
    {
        return _navigationStore.CurrentWindow;  
    }
   
}