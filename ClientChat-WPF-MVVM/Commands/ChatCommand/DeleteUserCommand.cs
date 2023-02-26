using ClientChat_WPF_MVVM.Model.ChatModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.ChatCommand;
public class DeleteUserCommand : CommandAsyncBase
{
    private readonly ChatViewModel _chatViewModel;

    public DeleteUserCommand(ChatViewModel chatViewModel)
    {
        _chatViewModel = chatViewModel;
    }
    public async override Task ExecuteAsync(object parameter)
    {
        
        var newList=_chatViewModel.Conversations.Where(e=>e.Id!=_chatViewModel.SelectedConversation.Id).ToList();
            _chatViewModel.Conversations.Clear();

        foreach (var conversation in newList)
        {
            _chatViewModel.Conversations.Add(conversation);

        }
        _chatViewModel.FindFriend = "";
    }
}
