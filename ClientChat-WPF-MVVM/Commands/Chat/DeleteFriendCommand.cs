using ClientChat_WPF_MVVM.Services.API.Chat;
using ClientChat_WPF_MVVM.View.UserControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.Commands.Chat;
public class DeleteFriendCommand : CommandAsyncBase
{
    private readonly IFriendService _friendService;
    private readonly ICommand _getFriendsCommand;

    public DeleteFriendCommand(IFriendService friendService, ICommand getFriendsCommand)
    {
        _friendService = friendService;
        _getFriendsCommand = getFriendsCommand;
    }
    public override async Task ExecuteAsync(object parameter)
    {
        try
        {
            await _friendService.DeleteFriend((parameter as string));
            _getFriendsCommand.Execute(null);
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
