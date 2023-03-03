using ClientChat_WPF_MVVM.Commands;
using ClientChat_WPF_MVVM.HostBuilders;
using ClientChat_WPF_MVVM.HttpClintContext;
using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API.Authentication;
using ClientChat_WPF_MVVM.Services.JsonSerialization;
using ClientChat_WPF_MVVM.Services.LoggerService;
using ClientChat_WPF_MVVM.Services.Serialization;
using ClientChat_WPF_MVVM.Services.TokentServices;
using ClientChat_WPF_MVVM.Strore;
using ClientChat_WPF_MVVM.View;
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


                    
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<UserStore>();
                
                services.AddSingleton<UserProfileModel>();
                services.AddSingleton<UserStoreServices>();

                services.AddSingleton<ISerialization,SerializationServices>();
                services.AddSingleton<TokenServieces>();
                services.AddSingleton<Logger>();
                services.AddSingleton<UndoRedoStoreStringSearch>();

                services.AddSingleton<AuthUserService<UserAuthInfoModel>>();
                services.AddSingleton(new HttpConnection(hostContext.Configuration.GetValue<string>("ServerUrl")));


                services.AddSingleton<NavigationWindowStore>();
                services.AddSingleton<ChatView>();

                services.AddSingleton(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });
            })
            .Build();

    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

   

        NavigationService<RegistrationViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<RegistrationViewModel>>();

        navigationService.Navigate();

        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();
        MainWindow.Cursor = new System.Windows.Input.Cursor(Application.GetResourceStream(new Uri(@"./CustomUI/Circle.cur", UriKind.Relative)).Stream);
        ResourceDictionary dict = new ResourceDictionary();
        //switch (Thread.CurrentThread.CurrentCulture.ToString())
        //{
        //    case "en-US":
        //        dict.Source = new Uri("D:\\asp\\ClientChat-WPF-MVVM\\ClientChat-WPF-MVVM\\View\\Resource\\StringResourceEN.xaml");
        //        break;
        //    case "ru-RU":
        //        dict.Source = new Uri("D:\\asp\\ClientChat-WPF-MVVM\\ClientChat-WPF-MVVM\\View\\Resource\\StringResourceRU.xaml");
        //        break;

        //}

        dict.Source = new Uri("D:\\asp\\ClientChat-WPF-MVVM\\ClientChat-WPF-MVVM\\View\\Resource\\StringResourceEN.xaml");


        MainWindow.Resources.MergedDictionaries.Add(dict);

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.Dispose();

        base.OnExit(e);
    }
}