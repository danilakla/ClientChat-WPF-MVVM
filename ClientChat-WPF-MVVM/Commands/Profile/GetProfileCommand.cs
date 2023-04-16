using ClientChat_WPF_MVVM.Services.API.Profile;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ClientChat_WPF_MVVM.Commands.Profile;
public class GetProfileCommand : CommandAsyncBase
{
    private readonly IProfileService _profileService;
    private readonly ProfileViewModel _profileViewModel;
    private readonly string[] list;

    public GetProfileCommand(IProfileService profileService, ProfileViewModel profileViewModel, string[ ]list )
    {
        _profileService = profileService;
        _profileViewModel = profileViewModel;
        this.list = list;
    }
    public async override Task ExecuteAsync(object parameter)
    {
        try
        {
    var profile = await _profileService.GetProfile();
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

            _profileViewModel.ProfileModel = profile;
        }
        catch (Exception)
        {

            throw;
        }
    

    }
}
