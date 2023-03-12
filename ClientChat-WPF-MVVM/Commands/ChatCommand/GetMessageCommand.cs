using ClientChat_WPF_MVVM.HttpClintContext;
using ClientChat_WPF_MVVM.Model.ChatModels;
using ClientChat_WPF_MVVM.Services.API.ChatHub;
using ClientChat_WPF_MVVM.View;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ClientChat_WPF_MVVM.Commands.ChatCommand
{
    class GetMessageCommand : CommandAsyncBase
    {
        private readonly ChatViewModel _chatViewModel;
        private readonly ChatView _chatView;

        public GetMessageCommand(ChatViewModel chatViewModel, ChatView chatView)
        {
            _chatViewModel = chatViewModel;
            _chatView = chatView;
        }
        public override async Task ExecuteAsync(object parameter)
        {


            ConnectionToChat.Connection.On<string, string>("ReceiveMessage", (user, message) =>
            {

                _chatView.Dispatcher.Invoke(() =>
                {



                    var ms = new MessageModel() { From = user, imageUrl = ".", Text = message, Time = System.DateTime.Now };
                    if (user == _chatViewModel.User.Email)
                    {
                        ms.IsOwned = true;
                    }
                    else
                    {

                        ms.IsOwned = false;
                    }


                    if (user == _chatViewModel.User.Email)
                    {
                        var friendProfile = _chatViewModel.Conversations.FirstOrDefault(e => e.FriendProfile.Email == _chatViewModel.SelectedConversation.FriendProfile.Email);
                        friendProfile.MessageModels.Add(ms);
                        _chatViewModel.MessagesForSelectedConversation.Add(ms);

                    }
                    else
                    {
                        var friendProfile = _chatViewModel.Conversations.FirstOrDefault(e => e.FriendProfile.Email == user);
                        friendProfile.MessageModels.Add(ms);
                        if (user == _chatViewModel.SelectedConversation.FriendProfile.Email)
                        {
                            _chatViewModel.MessagesForSelectedConversation.Add(ms);

                        }
                    }
                    
                });

            });
            await ConnectionToChat.Connection.StartAsync();


        }
    }
}
