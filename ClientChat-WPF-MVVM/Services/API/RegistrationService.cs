using ClientChat_WPF_MVVM.DTO.Client;
using ClientChat_WPF_MVVM.DTO.Server;
using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Services.TokenService;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API;

public class RegistrationService : IRegistrationService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenService _tokenService;
    private readonly string IdentityApiHost;

    public RegistrationService(HttpClient httpClient, IConfiguration configuration, ITokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
        IdentityApiHost = configuration["ApiHost"];
    }


    public async Task RegistrationUniversity(CreateUniversityDTO createUniversityDTO)
    {
        try
        {
            var uri = API.Identity.RegistrationUniversity(IdentityApiHost);
            var reqBody = new AddUniversityAndManager
            {
                University = new University { Address = createUniversityDTO.Address, Name = createUniversityDTO.NameOfUniversity },
                Email = createUniversityDTO.Email,
                Name = createUniversityDTO.Name,
                LastName = createUniversityDTO.LastName,
                Password = createUniversityDTO.Password,
                Role = "Manager"

            };
            var stringContent = new StringContent(JsonSerializer.Serialize(reqBody), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {

            throw e;
        }


    }

    public async Task RegistrationUser(RegistrationUserDTO registrationUserDTO)
    {
        try
        {
            string uri = "";
            if (registrationUserDTO.Role == "Student")
            {
                uri =  API.Identity.RegistrationStudent(IdentityApiHost);
            }
            else
            {
                uri = API.Identity.RegistrationUser(IdentityApiHost);
            }

            var stringContent = new StringContent(JsonSerializer.Serialize(registrationUserDTO), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();
            if (registrationUserDTO.Role == "Student")
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var tokens = JsonSerializer.Deserialize<JwtTokens>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                _tokenService.SetTokens(tokens);
            }
        }
        catch (Exception)
        {

            throw;
        }


    }
}
