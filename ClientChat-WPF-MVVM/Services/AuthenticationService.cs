
using ClientChat_WPF_MVVM.DTO.Server;
using ClientChat_WPF_MVVM.Infrastructure;
using ClientChat_WPF_MVVM.Model;
using Microsoft.Extensions.Configuration;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services;

public class AuthenticationService : IAuthenticationService
{

    private readonly HttpClient _httpClient;
    private readonly string IdentityApiHost;

    public AuthenticationService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        IdentityApiHost = configuration["ApiHost"];
    }

    public async Task<JwtTokens> LoginUser(AuthDto userModel)
    {
        try
        {
            string uri = uri = API.Identity.AuthUser(IdentityApiHost);

          
            var stringContent = new StringContent(JsonSerializer.Serialize(userModel), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var tokens=JsonSerializer.Deserialize<JwtTokens>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return tokens;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
