using ClientChat_WPF_MVVM.DTO.Server;
using ClientChat_WPF_MVVM.DTO.Server.Chat;
using ClientChat_WPF_MVVM.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClientChat_WPF_MVVM.Services.TokenService;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace ClientChat_WPF_MVVM.Services.API.Chat
{
    public class NotificationService : INotificationService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private readonly string ChatApiHost;

        public NotificationService(IConfiguration configuration, HttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            ChatApiHost = configuration["ApiHostChat"];

        }
        public async Task<List<Notification>> GetNotifications()
        {
            try
            {
                string uri = uri = API.Chat.GetNotification(ChatApiHost);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);
                var response = await _httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var notifications = JsonSerializer.Deserialize<List<Notification>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return notifications;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SendNotification(CreateNotificationDTO createNotificationDTO)
        {
            try
            {
                string uri = uri = API.Chat.SendNotification(ChatApiHost);

           
                var stringContent = new StringContent(JsonSerializer.Serialize(createNotificationDTO), System.Text.Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);

                var response = await _httpClient.PostAsync(uri, stringContent);
                response.EnsureSuccessStatusCode();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
