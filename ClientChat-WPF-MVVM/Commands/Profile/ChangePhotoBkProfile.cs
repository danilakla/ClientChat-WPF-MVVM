using ClientChat_WPF_MVVM.Services.API.Profile;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.Profile;
public class ChangePhotoBkProfile : CommandAsyncBase
{
    private readonly IProfileService _profileService;

    public ChangePhotoBkProfile(IProfileService profileService)
    {
        _profileService = profileService;
    }
    public async override Task ExecuteAsync(object parameter)
    {
        var dialog = new Microsoft.Win32.OpenFileDialog();

        // Show open file dialog box
        bool? result = dialog.ShowDialog();

        // Process open file dialog box results
        if (result == true)
        {
            // Open document
            await _profileService.UpdatePhotoBack(dialog);
        }
    }
}
