using ClientChat_WPF_MVVM.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClientChat_WPF_MVVM.Services.TokenService;
using Microsoft.Extensions.Configuration;

namespace ClientChat_WPF_MVVM.Services.API.Chat
{
    public class ChatService : IChatService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private readonly string ChatApiHost;

        public ChatService(IConfiguration configuration, HttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            ChatApiHost = configuration["ApiHostChat"];

        }
        public async Task<List<Message>> GetMessages(string roomName)
        {
            try
            {
                string uri = uri = API.Chat.GetMessages(ChatApiHost, roomName);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);
                var response = await _httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var messages = JsonSerializer.Deserialize<List<Message>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return messages;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
