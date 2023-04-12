using ClientChat_WPF_MVVM.View;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM.Commands
{
    class TestCommand : CommandAsyncBase
    {
        private readonly IHost _host;
        private readonly HttpClient _httpClient;

        public TestCommand(IHost host, HttpClient httpClient)
        {
            _host = host;
            _httpClient = httpClient;
        }
        

        public async override Task ExecuteAsync(object parameter)
        {
            var currentWindow = _host.Services.GetRequiredService<ChatView>();
            var context = _host.Services.GetRequiredService<ChatNavigationViewModel>();
            currentWindow.DataContext = context;
            currentWindow.Show();
            Application.Current.MainWindow.Owner = currentWindow;
            Application.Current.MainWindow.Close();
        }
    }
}
