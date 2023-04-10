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

namespace ClientChat_WPF_MVVM.Commands
{
    class TestCommand : CommandBase
    {
        private readonly IHost _host;

        public TestCommand(IHost host )
        {
            _host = host;
        }
        public override void Execute(object parameter)
        {
            var currentWindow = _host.Services.GetRequiredService< ChatView >();
            var context= _host.Services.GetRequiredService<ChatNavigationViewModel>();
            currentWindow.DataContext = context;
            currentWindow.Show();
            Application.Current.MainWindow.Owner = currentWindow;
            Application.Current.MainWindow.Close();
        }
    }
}
