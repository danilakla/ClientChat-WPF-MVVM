﻿
using ClientChat_WPF_MVVM.Services.API.Chat;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.NotificationCommand
{
    public class DeleteNotificationCommand : CommandAsyncBase
    {
        private readonly INotificationService _notificationService;
        private readonly NotificationViewModel _notificationViewModel;
        private readonly StartRoomViewModel _startRoomViewModel;

        public DeleteNotificationCommand(INotificationService notificationService, NotificationViewModel notificationViewModel, StartRoomViewModel startRoomViewModel)
        {
            _notificationService = notificationService;
            _notificationViewModel = notificationViewModel;
            _startRoomViewModel = startRoomViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await _notificationService.DeleteNotification((int)parameter);
            var notification = await _notificationService.GetNotifications();
            if(notification is not null)
            {
                _notificationViewModel.Notifications=notification;
            }
            else
            {
                _notificationViewModel.Notifications = null;
            }
            _notificationViewModel.SelectedNotification = _startRoomViewModel;
        }
    }
}
