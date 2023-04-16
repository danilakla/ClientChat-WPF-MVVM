using ClientChat_WPF_MVVM.DTO.Server;
using ClientChat_WPF_MVVM.Models.Profile;
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

namespace ClientChat_WPF_MVVM.Services.API.Skill;
public class SkillService : ISkillService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenService _tokenService;
    private readonly string ProfileApiHost;

    public SkillService(IConfiguration configuration, HttpClient httpClient, ITokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
        ProfileApiHost = configuration["ApiHostProfile"];

    }
    public async Task AddSkill(SkillModel skillViewModel)
    {
        try
        {
            string uri = uri = API.Profile.AddSkill(ProfileApiHost);

            var reqBody = new CreateSkillDto
            {
                Text = skillViewModel.Text,
            };
            var stringContent = new StringContent(JsonSerializer.Serialize(reqBody), System.Text.Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task DeleteSkill(int id)
    {
        try
        {
            string uri = uri = API.Profile.DeleteSkill(ProfileApiHost, id);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);


            var response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<SkillModel> GetSkill(int id)
    {
        try
        {
            string uri = uri = API.Profile.GetSkill(ProfileApiHost, id);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);


            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var skill = JsonSerializer.Deserialize<SkillModel>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return skill;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task UpdateSkill(SkillModel skillViewModel)
    {
        try
        {
            string uri = uri = API.Profile.UpdateSkill(ProfileApiHost);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);

            var stringContent = new StringContent(JsonSerializer.Serialize(skillViewModel), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }
}
