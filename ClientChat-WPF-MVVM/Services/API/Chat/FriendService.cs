using ClientChat_WPF_MVVM.DTO.Server.Chat;
using ClientChat_WPF_MVVM.Models.Chat;
using ClientChat_WPF_MVVM.Services.TokenService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API.Chat
{
    class FriendService : IFriendService
    {

        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private readonly string ChatApiHost;

        public FriendService(IConfiguration configuration, HttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            ChatApiHost = configuration["ApiHostChat"];

        }

        public async Task AddFriend(int idNotification)
        {
            try
            {
                string uri = uri = API.Chat.AddFriend(ChatApiHost);


                var stringContent = new StringContent(JsonSerializer.Serialize(new { NotificationId =idNotification}), System.Text.Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);

                var response = await _httpClient.PostAsync(uri, stringContent);
                response.EnsureSuccessStatusCode();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteFriend(string nameRoom)
        {
            try
            {
                string uri = uri = API.Chat.DeleteFriend(ChatApiHost, nameRoom);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);
                var response = await _httpClient.DeleteAsync(uri);
                response.EnsureSuccessStatusCode();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Friend>> GetFriends()
        {
            try
            {
                string uri = uri = API.Chat.GetFriends(ChatApiHost);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);
                var response = await _httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var friends = JsonSerializer.Deserialize<List<Friend>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return friends;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
