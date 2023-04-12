using ClientChat_WPF_MVVM.DTO.Server;
using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Services.TokenService;
using Microsoft.Extensions.Configuration;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API;

public class AuthenticationService : IAuthenticationService
{

    private readonly HttpClient _httpClient;
    private readonly ITokenService _tokenService;
    private readonly string IdentityApiHost;

    public AuthenticationService(HttpClient httpClient, IConfiguration configuration, ITokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
        IdentityApiHost = configuration["ApiHost"];
    }

    public async Task<JwtTokens> LoginUser(AuthDto userModel)
    {
        try
        {
            var reqBody = new UserModel { Email = userModel.Email, Password = userModel.Password, LastName = "em", Name = "em" };
            string uri = uri = API.Identity.AuthUser(IdentityApiHost);


            var stringContent = new StringContent(JsonSerializer.Serialize(reqBody), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var tokens = JsonSerializer.Deserialize<JwtTokens>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            _tokenService.SetTokens(tokens);
            return tokens;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
