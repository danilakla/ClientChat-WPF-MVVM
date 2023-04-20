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
    public class ContactService : IContactService
    {

        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private readonly string ChatApiHost;

        public ContactService(IConfiguration configuration, HttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            ChatApiHost = configuration["ApiHostChat"];

        }
        public async Task<List<Contact>> GetContacts(string name, string lastName)
        {
            try
            {
                string uri = uri = API.Chat.GetContacts(ChatApiHost,name,lastName);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);
                var response = await _httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var contacts = JsonSerializer.Deserialize<List<Contact>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return contacts;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
