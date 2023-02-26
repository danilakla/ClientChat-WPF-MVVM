using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Model.ChatModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.ChatCommand
{
    class AddFriendCommand : CommandAsyncBase
    {
        private readonly ChatViewModel _chatViewModel;

        public AddFriendCommand(ChatViewModel  chatViewModel)
        {
            _chatViewModel = chatViewModel;
        }
        public async override Task ExecuteAsync(object parameter)
        {
        
            var d=_chatViewModel.Users.Where(d=>d.Email==_chatViewModel.Text).FirstOrDefault();

            if (d is null || d.Name.Length<3)
            {

            }
            else
            {
                _chatViewModel.Conversations.Add(new ConversationModel { Id = _chatViewModel.Count, FriendProfile = d });
            }
            _chatViewModel.FindFriend = "";
        }
    }
}
