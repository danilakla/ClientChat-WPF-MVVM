using ClientChat_WPF_MVVM.HttpClintContext;
using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Model.ChatModels;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ClientChat_WPF_MVVM.Model.Dto;

namespace ClientChat_WPF_MVVM.Services.API.UserChatServices
{


    class UserChatServicec
    {

        private readonly HttpConnection _httpConnection;

        public UserChatServicec(HttpConnection httpConnection)
        {
            _httpConnection = httpConnection;
        }

        public async Task<IEnumerable<ConversationModel>> LoadFriends(int UserId) {

            try
            {
                using (var connection = _httpConnection.CreateHttpContext())
                {
                    HttpResponseMessage response =
                         await connection.GetAsync($"");
                    response.EnsureSuccessStatusCode();
                    string userInfo =
                       await response.Content.ReadAsStringAsync();
                    var UserAccessToken = JsonConvert.DeserializeObject<IEnumerable<ConversationModel>>(userInfo);
                    return UserAccessToken;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<ConversationModel> AddFriend(AddFriendDto addFriendDto)
        {

            try
            {
                using (var connection = _httpConnection.CreateHttpContext())
                {
                    HttpResponseMessage response =
                         await connection.PostAsJsonAsync($"", addFriendDto);
                    response.EnsureSuccessStatusCode();
                    string conversation =
                       await response.Content.ReadAsStringAsync();
                    var ConversationJson = JsonConvert.DeserializeObject<ConversationModel>(conversation);
                    return ConversationJson;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
