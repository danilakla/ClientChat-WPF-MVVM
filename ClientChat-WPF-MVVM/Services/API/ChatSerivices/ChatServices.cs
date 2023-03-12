using ClientChat_WPF_MVVM.Commands;
using ClientChat_WPF_MVVM.HttpClintContext;
using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Model.ChatModels;
using ClientChat_WPF_MVVM.Model.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClientChat_WPF_MVVM.Services.API.ChatSerivices
{
    public class ChatServices
    {
        private readonly HttpConnection _httpConnection;

        public ChatServices(HttpConnection httpConnection)
        {
            _httpConnection = httpConnection;
        }


        public async Task<IEnumerable<MessageModel>> LoadMessages(ChatViewModel chatViewModel)
        {

            try
            {
                using (var connection = _httpConnection.CreateHttpContext())
                {

                    UriBuilder builder = new UriBuilder("https://localhost:7161/api/Message/load-message");
                    var query = HttpUtility.ParseQueryString(builder.Query);
                    query["user"] = chatViewModel.User.Email;
                    query["userFriend"] = chatViewModel.SelectedConversation.FriendProfile.Email;
                    builder.Query = query.ToString();


                    HttpResponseMessage response =
                         await connection.GetAsync(builder.Uri);
                    response.EnsureSuccessStatusCode();
                    string res =
                       await response.Content.ReadAsStringAsync();
                    var messages = JsonConvert.DeserializeObject<IEnumerable<MessageModel>>(res);
                    return messages;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<ObservableCollection<ProfileDto>> LoadFriends(ChatViewModel chatViewModel)
        {

            try
            {
                using (var connection = _httpConnection.CreateHttpContext())
                {

                    UriBuilder builder = new UriBuilder("https://localhost:7161/api/Conversation/loadFriend");
                    var query = HttpUtility.ParseQueryString(builder.Query);
                    query["user"] = chatViewModel.User.Email;
                    builder.Query = query.ToString();


                    HttpResponseMessage response =
                         await connection.GetAsync(builder.Uri);
                    response.EnsureSuccessStatusCode();
                    string res =
                       await response.Content.ReadAsStringAsync();
                    if (res.Contains("result\":[]"))
                    {
                        return null;
                    }
                    else
                    {  
                        var friends = JsonConvert.DeserializeObject<IEnumerable<ProfileDto>>(res);
                        var colFriends = new ObservableCollection<ProfileDto>();
                        foreach (var item in friends)
                        {
                            colFriends.Add(item);
                        }
                        return colFriends;

                    }
           
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
