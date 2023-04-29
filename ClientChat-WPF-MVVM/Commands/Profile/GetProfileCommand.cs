using ClientChat_WPF_MVVM.Infrastructure;
using ClientChat_WPF_MVVM.Services.API.Profile;
using ClientChat_WPF_MVVM.Utils;
using ClientChat_WPF_MVVM.View.UserControllers;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace ClientChat_WPF_MVVM.Commands.Profile;
public class GetProfileCommand : CommandAsyncBase
{
    private readonly IProfileService _profileService;
    private readonly ProfileViewModel _profileViewModel;
    private readonly string[] list;
    private readonly IImgService _imgService;
    private readonly IConfiguration _configuration;

    public GetProfileCommand(IProfileService profileService,
        ProfileViewModel profileViewModel, 
        string[ ]list,
        IImgService imgService,
        IConfiguration configuration)
    {
        _profileService = profileService;
        _profileViewModel = profileViewModel;
        this.list = list;
        _imgService = imgService;
        _configuration = configuration;
    }
    public async override Task ExecuteAsync(object parameter)
    {
        try
        {
            var profile = await _profileService.GetProfile();
            UserStore.Email=profile.UserDataModel.Email;
            #region
            foreach (var item in profile.ProjectModels)
            {
                foreach (var tech in item.NameUsingTech.ToCharArray())
                {
                    item.urltech = new();
                    switch (tech)
                    {
                        case '1':

                            item.urltech.Add(list[0]);


                            break;
                        case '2':
                            item.urltech.Add(list[1]);


                            break;
                        case '3':

                            item.urltech.Add(list[2]);

                            break;
                        case '4':

                            item.urltech.Add(list[3]);

                            break;
                        case '5':
                            item.urltech.Add(list[4]);

                            break;
                    }
                }
            }

            #endregion
            if (profile.UserDataModel.Photo is null)
            {
                
                profile.UserDataModel.Photo=await _imgService.SetDefaultImage(_configuration["Icon"]);

            }
            if (profile.UserDataModel.BackgroundProfile is null)
            {
                profile.UserDataModel.BackgroundProfile = await _imgService.SetDefaultImage(_configuration["BackImg"]);

            }
            _profileViewModel.ProfileModel = profile;
        }
        catch (Exception e)
        {
            Window window = new Window
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 300,
                Height = 200,
                Title = "Error",
                Content = new Reject(e.Message)
            };
            window.ShowDialog();
        }
    

    }
}
