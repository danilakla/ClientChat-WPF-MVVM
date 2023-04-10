using ClientChat_WPF_MVVM.HostBuilders;
using ClientChat_WPF_MVVM.HttpClintContext;

using ClientChat_WPF_MVVM.View;
using ClientChat_WPF_MVVM.View.UserControllers.Preview;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .AddViewModels()
            .ConfigureServices((hostContext, services) =>
            {


             



                services.AddSingleton(new HttpConnection(hostContext.Configuration.GetValue<string>("ServerUrl")));
                services.AddSingleton<NavigationPreviewViewModel>();
                services.AddSingleton<RegistationUniverstityViewModel>();
                services.AddSingleton<LoginViewModel>();
                services.AddSingleton<RegistrationViewModel>();
                services.AddSingleton<PreviewView>();
                services.AddSingleton<ChatView>();
                services.AddSingleton<ChatNavigationViewModel>();


            })
            .Build();

    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

   



        MainWindow = _host.Services.GetRequiredService<PreviewView>();
        MainWindow.DataContext = _host.Services.GetRequiredService<NavigationPreviewViewModel>();
        MainWindow.Show();
     
       

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.Dispose();

        base.OnExit(e);
    }
}