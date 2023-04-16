using ClientChat_WPF_MVVM.Models.Profile;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API.Profile;
public interface IProfileService
{
    Task<ProfileModel> GetProfile();
    Task UpdateProfile(UpdateProfileModel updateProfileViewModel);
    Task UpdatePhoto(OpenFileDialog openFileDialog);
    Task UpdatePhotoBack(OpenFileDialog openFileDialog);


}
