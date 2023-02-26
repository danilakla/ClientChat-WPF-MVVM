using ClientChat_WPF_MVVM.Model.ChatModels;
using ClientChat_WPF_MVVM.Model.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM.Commands.ChatCommand
{
    class SendMessageCommand : CommandBase
    {
        private readonly ChatViewModel _chatViewModel;
        private static int c = 0;
        public SendMessageCommand(ChatViewModel chatViewModel)
        {
            _chatViewModel = chatViewModel;
        }


        public override void Execute(object parameter)
        {
            if (_chatViewModel.SelectedConversation == null)
            {
            }
           
            var testData= new SendingMessageDto { Text = _chatViewModel.Message, Time = DateTime.Now, From = _chatViewModel.User.Email,ConversationId=_chatViewModel.SelectedConversation.Id};
            var ms = new MessageModel() { From=testData.From, imageUrl=_chatViewModel.SelectedConversation.FriendProfile.profileImage, Text=testData.Text.ToString(),Time=testData.Time };
            if(testData.From==_chatViewModel.User.Email&&c>5)
            {
                ms.From = "first";
                ms.IsOwned= true;
            }
            else
            {
                ms.From = "second";

                ms.IsOwned = false;
            }
            c++;
            _chatViewModel.MessagesForSelectedConversation.Add(ms);
            Console.WriteLine("Dsds");
        }
    }
}
