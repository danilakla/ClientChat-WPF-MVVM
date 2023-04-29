using ClientChat_WPF_MVVM.Services.API.Chat;
using ClientChat_WPF_MVVM.View.UserControllers;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM.Commands.ContactModalCommands;
public class SendNotificaitonCommand : CommandAsyncBase
{
    private readonly FindUserDialogViewModel _findUserDialogViewModel;
    private readonly INotificationService _notificationService;

    public SendNotificaitonCommand(FindUserDialogViewModel findUserDialogViewModel, 
        INotificationService notificationService)
    {
        _findUserDialogViewModel = findUserDialogViewModel;
        _notificationService = notificationService;
    }
    public override async Task ExecuteAsync(object parameter)
    {
        try
        {
            await _notificationService.SendNotification(new() { FriendId = (int)parameter, MessageBody = "let's go be friends" });
            Window window = new Window
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 300,
                Height = 200,
                Title = "Success",
                Content = new Success()
            };
            window.ShowDialog();
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
