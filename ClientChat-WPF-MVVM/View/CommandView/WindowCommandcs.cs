using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ClientChat_WPF_MVVM.View.CommandView;
public class WindowCommands
{

    static WindowCommands()
       
    {
        Exit = new RoutedCommand("Exit", typeof(Window));
    }
    public static RoutedCommand Exit { get; set; }
}
