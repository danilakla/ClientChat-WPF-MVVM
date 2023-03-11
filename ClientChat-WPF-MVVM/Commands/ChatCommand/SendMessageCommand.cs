using ClientChat_WPF_MVVM.Model.ChatModels;
using ClientChat_WPF_MVVM.Model.Dto;
using ClientChat_WPF_MVVM.Services.API.ChatHub;
using ClientChat_WPF_MVVM.View;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM.Commands.ChatCommand
{
    class SendMessageCommand : CommandAsyncBase
    {
        private readonly ChatViewModel _chatViewModel;
        private readonly ChatView _chatView;
        private static int c = 0;
        public SendMessageCommand(ChatViewModel chatViewModel, ChatView chatView)
        {
            _chatViewModel = chatViewModel;
            _chatView = chatView;
        }


        public override async Task ExecuteAsync(object parameter)
        {


            //var testData = new SendingMessageDto { Text = _chatViewModel.Message, Time = DateTime.Now, From = _chatViewModel.User.Email, ConversationId = _chatViewModel.SelectedConversation.Id };
            await ConnectionToChat.Connection.InvokeAsync("SendMessage", _chatViewModel.User.Email, _chatViewModel.Message,_chatViewModel.SelectedConversation.FriendProfile.Name);



           

        }
    }
}
