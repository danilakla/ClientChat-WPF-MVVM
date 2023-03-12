using ClientChat_WPF_MVVM.Services.API.ChatSerivices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.ChatCommand;
internal class SelectConversationCommand : CommandAsyncBase
{
    private readonly ChatViewModel _chatViewModel;
    private readonly ChatServices _chatServices;

    public SelectConversationCommand(ChatViewModel chatViewModel,ChatServices  chatServices)
    {
        _chatViewModel = chatViewModel;
        _chatServices = chatServices;
    }
    public override async Task ExecuteAsync(object parameter)
    {
   
        if (!(_chatViewModel.SelectedConversation is null)) {
            if (_chatViewModel.MessagesForSelectedConversation is null)
            {
                _chatViewModel.MessagesForSelectedConversation = new();
            }
            _chatViewModel.MessagesForSelectedConversation.Clear();
            var pickConversation = _chatViewModel.Conversations.FirstOrDefault(e => e.FriendProfile.Email == _chatViewModel.SelectedConversation.FriendProfile.Email);
            if (!(pickConversation.MessageModels is null))
            {

                foreach (var item in pickConversation.MessageModels)
                {
                    _chatViewModel.MessagesForSelectedConversation.Add(item);

                }
                var messages = await _chatServices.LoadMessages(_chatViewModel);
                if (messages != null)
                {

                    foreach (var item in messages)
                    {
                        if (_chatViewModel.User.Email== item.From)
                        {
                            item.IsOwned = true;
                        }
                        else
                        {

                            item.IsOwned = false;
                        }
                        _chatViewModel.MessagesForSelectedConversation.Add(item);

                    }
                }
            }

           
        }
     
     
    }

 
}
