using ClientChat_WPF_MVVM.DTO.Server;
using ClientChat_WPF_MVVM.Models.Profile;
using ClientChat_WPF_MVVM.Services.TokenService;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API.Profile;
public class ProfileService : IProfileService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenService _tokenService;
    private readonly string ProfileApiHost;

    public ProfileService(IConfiguration configuration, HttpClient httpClient, ITokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
        ProfileApiHost = configuration["ApiHostProfile"];

    }
    public async Task<ProfileModel> GetProfile()
    {
        try
        {
            string uri = uri = API.Profile.GetProfile(ProfileApiHost);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var profileJson = JsonSerializer.Deserialize<GetProfileDTO>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var profile = new ProfileModel
            {
                
                ProjectModels= profileJson.Projects,
                SkillModels = profileJson.Skills,
                UserDataModel = new UserDataModel
                {
                    BackgroundProfile = profileJson.BackgroundProfile,
                    Description = profileJson.Description,
                    Email = profileJson.Email,
                    LastName = profileJson.LastName,
                    Name = profileJson.Name,
                    Photo = profileJson.Photo,
                    UniversityName = profileJson.UniversityName,

                }
            };
            return profile;
        }
        catch (Exception)
        {

            throw;
        }



    }

    public async Task UpdatePhoto(OpenFileDialog openFileDialog)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);
        var uri = API.Profile.UpdateIconProfile(ProfileApiHost);

        await using var stream = openFileDialog.OpenFile();
        using var request = new HttpRequestMessage(HttpMethod.Put, uri);
        using var content = new MultipartFormDataContent
    {
        { new StreamContent(stream), "photo", openFileDialog.FileName }
    };


        request.Content = content;

        var res = await _httpClient.SendAsync(request);
    }

    public async Task UpdatePhotoBack(OpenFileDialog openFileDialog)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);
        var uri = API.Profile.UpdateBgProfile(ProfileApiHost);

        await using var stream = openFileDialog.OpenFile();
        using var request = new HttpRequestMessage(HttpMethod.Put, uri);
        using var content = new MultipartFormDataContent
    {
        { new StreamContent(stream), "photo", openFileDialog.FileName }
    };


        request.Content = content;

        var res = await _httpClient.SendAsync(request);
    }

    public async Task UpdateProfile(UpdateProfileModel updateProfileViewModel)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetTokens().AccessToken);

            if (updateProfileViewModel.Icon != null)
            {

                var uri = API.Profile.UpdateIconProfile(ProfileApiHost);

                await using var stream = updateProfileViewModel.Icon.OpenReadStream();
                using var request = new HttpRequestMessage(HttpMethod.Put, uri);
                using var content = new MultipartFormDataContent
    {
        { new StreamContent(stream), "photo", updateProfileViewModel.Icon.FileName }
    };


                request.Content = content;

                var res = await _httpClient.SendAsync(request);

            }

            if (updateProfileViewModel.Bg != null)
            {

                var uri1 = API.Profile.UpdateBgProfile(ProfileApiHost);

                await using var stream1 = updateProfileViewModel.Bg.OpenReadStream();
                using var request1 = new HttpRequestMessage(HttpMethod.Put, uri1);
                using var content1 = new MultipartFormDataContent
    {
        { new StreamContent(stream1), "photo", updateProfileViewModel.Bg.FileName }
    };


                request1.Content = content1;

                var res1 = await _httpClient.SendAsync(request1);
            }
        }

        catch (Exception)
        {

            throw;
        }
    }
}
