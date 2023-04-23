using ClientChat_WPF_MVVM.HostBuilders;
using ClientChat_WPF_MVVM.Infrastructure;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API;
using ClientChat_WPF_MVVM.Services.API.Chat;
using ClientChat_WPF_MVVM.Services.API.Profile;
using ClientChat_WPF_MVVM.Services.API.Project;
using ClientChat_WPF_MVVM.Services.API.Skill;
using ClientChat_WPF_MVVM.Services.Hub;
using ClientChat_WPF_MVVM.Services.TokenService;
using ClientChat_WPF_MVVM.Utils;
using ClientChat_WPF_MVVM.View;
using ClientChat_WPF_MVVM.View.UserControllers.Chat;
using ClientChat_WPF_MVVM.View.UserControllers.Preview;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.AspNetCore.SignalR.Client;
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
                services.AddHttpClient();
                services.AddSingleton<NavigationPreviewViewModel>();
                services.AddSingleton<RegistationUniverstityViewModel>();
                services.AddSingleton<LoginViewModel>();
                services.AddSingleton<RegistrationViewModel>();

                services.AddSingleton<PreviewView>();

                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IRegistrationService, RegistrationService>();
                services.AddSingleton<INavigationService, NavigationService>();

                services.AddSingleton<ISerialization, SerializationServices>();
                services.AddSingleton<ITokenService, TokenService>();

                services.AddSingleton<IProfileService, ProfileService>();
                services.AddSingleton<IProjectService, ProjectService>();
                services.AddSingleton<ISkillService, SkillService>();


                services.AddSingleton<IContactService, ContactService>();
                services.AddSingleton<IChatService, ChatService>();
                services.AddSingleton<INotificationService, NotificationService>();
                services.AddSingleton<IFriendService, FriendService>();

                services.AddSingleton<ChatView>();
                services.AddSingleton<ChatNavigationViewModel>();

                services.AddSingleton<WelcomeView>();
                services.AddSingleton<WelcomeChatViewModel>();


                services.AddTransient<ProfileViewModel>();

                services.AddSingleton<ConfirmEmailViewModel>();

                services.AddSingleton<ChatBarViewModel>();

                services.AddSingleton<ChatRoomViewModel>();
                services.AddSingleton<RoomViewModel>();
                services.AddSingleton<StartRoomViewModel>();

                services.AddSingleton<FindUserDialogViewModel>();

                services.AddSingleton<NotificationBarViewModel>();

                services.AddSingleton<NotificationViewModel>();

                services.AddSingleton<SelectedNotificationViewModel>();
                services.AddSingleton<IImgService,ImgService>();

                //ws
                services.AddScoped<WSSConnection>();
                services.AddSingleton<Func<HubConnection>>(  () =>
                {
                    var tokenService = _host.Services.GetRequiredService<ITokenService>();

                    var Connection = new HubConnectionBuilder()
                        .WithUrl(hostContext.Configuration["ChatHub"], async option =>
                             {
                          option.AccessTokenProvider = async  () => await Task.FromResult(tokenService.GetTokens().AccessToken);

                                     })
                                     .WithAutomaticReconnect()
                             .Build();
                    return Connection;
                });


                services.AddSingleton<IMessageHub, MessageHub>();




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