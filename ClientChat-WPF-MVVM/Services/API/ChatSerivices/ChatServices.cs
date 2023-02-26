using ClientChat_WPF_MVVM.HttpClintContext;
using ClientChat_WPF_MVVM.Model.ChatModels;
using ClientChat_WPF_MVVM.Model.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API.ChatSerivices
{
    public class ChatServices
    {
        private readonly HttpConnection _httpConnection;

        public ChatServices(HttpConnection httpConnection)
        {
            _httpConnection = httpConnection;
        }


        public async Task<IEnumerable<MessageModel>> LoadMessages(LoadMessageDto loadMessageDto)
        {

            try
            {
                using (var connection = _httpConnection.CreateHttpContext())
                {
                    HttpResponseMessage response =
                         await connection.PostAsJsonAsync($"d", loadMessageDto);
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

    }
}
