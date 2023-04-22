using ClientChat_WPF_MVVM.Services.API.Chat;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.Chat;
public class GetFriendsCommand : CommandAsyncBase
{
    private readonly ChatBarViewModel _chatBarViewModel;
    private readonly IFriendService _friendService;

    public GetFriendsCommand(ChatBarViewModel chatBarViewModel, IFriendService friendService)
    {
        _chatBarViewModel = chatBarViewModel;
        _friendService = friendService;
    }
    public async override Task ExecuteAsync(object parameter)
    {

        try
        {
            var friends = await _friendService.GetFriends();
            _chatBarViewModel.Friends = friends;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
