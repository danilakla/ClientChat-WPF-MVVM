using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands;
public class DebugCommand : CommandBase
{
    public override void Execute(object parameter)
    {
        Console.WriteLine("dsds");
    }
}
