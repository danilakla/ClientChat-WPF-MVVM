using ClientChat_WPF_MVVM.HttpClintContext;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.View;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.HostBuilders;
public static class AddViewModelsHostBuilderExtensions
{
    public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddTransient<LoginViewModel>();
            services.AddSingleton<Func<LoginViewModel>>((s) => () => s.GetRequiredService<LoginViewModel>());
            services.AddSingleton<NavigationService<LoginViewModel>>();



            services.AddTransient<RegistrationViewModel>();

            services.AddSingleton<Func<RegistrationViewModel>>((s) => () => s.GetRequiredService<RegistrationViewModel>());
            services.AddSingleton<NavigationService<RegistrationViewModel>>();
            services.AddSingleton<NavigationWindowService<ChatView>>();


            services.AddTransient<ChatViewModel>();
            services.AddSingleton<Func<ChatViewModel>>((s) => () => s.GetRequiredService<ChatViewModel>());
            services.AddSingleton<NavigationService<ChatViewModel>>();
            services.AddSingleton<Func<ChatView>>((s) => () => s.GetRequiredService<ChatView>());


            services.AddSingleton<NavigationWindowService<MainWindow>>();
            services.AddSingleton<MainViewModel>();

        });

        return hostBuilder;
    }

}
