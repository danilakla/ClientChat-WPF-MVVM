using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.ChatCommand;
public class UpDataUserDataCommand : CommandAsyncBase
{
    private readonly ChatViewModel _chatViewModel;

    public UpDataUserDataCommand(ChatViewModel chatViewModel)
    {
        _chatViewModel = chatViewModel;
    }
    public async override Task ExecuteAsync(object parameter)
    {
        var conModel=_chatViewModel.Conversations.Where(e => e.Id == _chatViewModel.SelectedConversation.Id).FirstOrDefault();
        conModel.FriendProfile.profileImage = _chatViewModel.NImga;
        conModel.FriendProfile.Name = _chatViewModel.NName;
        _chatViewModel.ChangeUser = false;
        _chatViewModel.IsView=true;
        _chatViewModel.FindFriend = "";

    }
}
