using ClientChat_WPF_MVVM.Services.API.Chat;
using ClientChat_WPF_MVVM.View.UserControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            try
            {
                await _friendService.AddFriend((int)parameter);
                _deleteNotificationCommand.Execute(parameter);
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
