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

namespace ClientChat_WPF_MVVM.Services.API.Project;
public class ProjectService : IProjectService
{

    private readonly HttpClient _httpClient;
    private readonly ITokenService _tokenService;
    private readonly string ProfileApiHost;

    public ProjectService(IConfiguration configuration, HttpClient httpClient, ITokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
        ProfileApiHost = configuration["ApiHostProfile"];

    }
    public async Task AddProject(ProjectModel projectViewModel)
    {
        try
        {
            string uri = uri = API.Profile.AddProject(ProfileApiHost);

            var reqBody = new CreateProjectDTO
            {
                Description = projectViewModel.Description,
                Name = projectViewModel.Name,
                NameUsingTech = projectViewModel.NameUsingTech,
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

    public async Task DeleteProject(int id)
    {
        try
        {
            string uri = uri = API.Profile.DeleteProject(ProfileApiHost, id);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);


            var response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<ProjectModel> GetProject(int id)
    {
        try
        {
            string uri = uri = API.Profile.GetProject(ProfileApiHost, id);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);


            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var project = JsonSerializer.Deserialize<ProjectModel>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return project;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public Task UpdateProject(ProjectModel projectViewModel)
    {
        throw new NotImplementedException();
    }
}
