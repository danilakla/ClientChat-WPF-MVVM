using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands
{
    class ToSelectedNotificationCommand:CommandBase
    {
        private readonly SelectedNotificationViewModel _selectedNotificationViewModel;
        private readonly NotificationViewModel _notificationViewModel;

        public ToSelectedNotificationCommand(SelectedNotificationViewModel selectedNotificationViewModel, NotificationViewModel notificationViewModel)
        {
            _selectedNotificationViewModel = selectedNotificationViewModel;
            _notificationViewModel = notificationViewModel;
        }

        public override void Execute(object parameter)
        {
            _notificationViewModel.SelectedNotification = _selectedNotificationViewModel;
        }
    }
}
