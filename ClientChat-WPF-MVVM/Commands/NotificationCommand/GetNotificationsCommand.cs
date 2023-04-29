using ClientChat_WPF_MVVM.Services.API.Chat;
using ClientChat_WPF_MVVM.View.UserControllers;
using ClientChat_WPF_MVVM.View.UserControllers.Notification;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM.Commands.NotificationCommand
{
    public class GetNotificationsCommand : CommandAsyncBase
    {
        private readonly NotificationViewModel _notificationViewModel;
        private readonly INotificationService _notificationService;

        public GetNotificationsCommand(NotificationViewModel notificationViewModel , INotificationService notificationService)
        {
            _notificationViewModel = notificationViewModel;
            _notificationService = notificationService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                _notificationViewModel.IsVisibleSpiner = System.Windows.Visibility.Visible;
                await Task.Delay(3000);
                var notifications = await _notificationService.GetNotifications();
                if (notifications is not null)
                {
                    _notificationViewModel.Notifications = notifications;
                }
                _notificationViewModel.IsVisibleSpiner = System.Windows.Visibility.Collapsed;
            }
            catch (Exception e)
            {

                Window window = new Window
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Width = 300,
                    Height = 200,
                    Title = "Error",
                    Content = new Reject(e.Message)
                };
                window.ShowDialog();
            }
            

        }

    }
}
