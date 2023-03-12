using ClientChat_WPF_MVVM.HttpClintContext;
using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Model.ChatModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ClientChat_WPF_MVVM.Model.Dto;

namespace ClientChat_WPF_MVVM.Commands.ChatCommand
{
    class AddFriendCommand : CommandAsyncBase
    {
        private readonly ChatViewModel _chatViewModel;
        private readonly HttpConnection _httpConnection;

        public AddFriendCommand(ChatViewModel  chatViewModel,HttpConnection httpConnection)
        {
            _chatViewModel = chatViewModel;
            _httpConnection = httpConnection;
        }
        public async override Task ExecuteAsync(object parameter)
        {
            AddFriendDto friendDto;
            try
            {
                using (var connection = _httpConnection.CreateHttpContext())
                {

                    HttpResponseMessage response =
                         await connection.PostAsJsonAsync("https://localhost:7161/api/Conversation/add-friend", new { UserFriend = _chatViewModel.Text, User=_chatViewModel.User.Email, ConversationName =" "});
                    response.EnsureSuccessStatusCode();
                    string userInfo =
                       await response.Content.ReadAsStringAsync();
                     friendDto = JsonConvert.DeserializeObject<AddFriendDto>(userInfo);
                }
            }
            catch (Exception)
            {

                throw;
            }

        
                _chatViewModel.Conversations.Add(new ConversationModel { Id = _chatViewModel.Count, FriendProfile = new UserProfileModel { Email = friendDto.EmailOfFriend, Name = friendDto.EmailOfFriend } });
         
            _chatViewModel.FindFriend = "";
        }
    }
}
