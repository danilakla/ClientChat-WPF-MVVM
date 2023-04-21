using ClientChat_WPF_MVVM.Services.API.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.Commands.NotificationCommand
{
    class AcceptNotificationCommand : CommandAsyncBase
    {
        private readonly ICommand _deleteNotificationCommand;
        private readonly IFriendService _friendService;

        public AcceptNotificationCommand(ICommand deleteNotificationCommand, IFriendService  friendService)
        {
            _deleteNotificationCommand = deleteNotificationCommand;
            _friendService = friendService;
        }
        public async override Task ExecuteAsync(object parameter)
        {

            await _friendService.AddFriend((int)parameter);
            _deleteNotificationCommand.Execute(parameter);  
        }
    }
}
