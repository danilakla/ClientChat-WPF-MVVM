using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands
{
    class ToNotificationViewCommand : CommandBase
    {
        private readonly ChatNavigationViewModel _chatNavigationViewModel;
        private readonly NotificationViewModel _notificationViewModel;

        public ToNotificationViewCommand(ChatNavigationViewModel chatNavigationViewModel, NotificationViewModel notificationViewModel)
        {
            _chatNavigationViewModel = chatNavigationViewModel;
            _notificationViewModel = notificationViewModel;
        }
        public override void Execute(object parameter)
        {
            _chatNavigationViewModel.SelectedViewModel= _notificationViewModel;
        }
    }
}
