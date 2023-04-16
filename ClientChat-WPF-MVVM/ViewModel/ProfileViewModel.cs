using ClientChat_WPF_MVVM.Commands.Profile;
using ClientChat_WPF_MVVM.Models.Profile;
using ClientChat_WPF_MVVM.Services.API.Profile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel
{
    public class ProfileViewModel:ViewModelBase
    {

        private ProfileModel _profileModel;

        public ProfileModel ProfileModel
        {
            get { return _profileModel; }
            set { _profileModel = value;
                OnPropertyChanged("ProfileModel");
            }

        }

        private object _selectedViewModel;
        public object ChatBarView
        {
            get => _selectedViewModel;
            set { _selectedViewModel = value; OnPropertyChanged("ChatBarView"); }
        }
       public string[] list = new string[] { "https://cdn-icons-png.flaticon.com/512/732/732007.png",
            "https://cdn-icons-png.flaticon.com/512/1051/1051328.png",
            "https://cdn-icons-png.flaticon.com/512/14/14427.png",
            "https://cdn-icons-png.flaticon.com/512/460/460771.png",
            "https://cdn-icons-png.flaticon.com/512/74/74897.png",



            };

        public ProfileViewModel(ChatBarViewModel chatBarViewModel, IProfileService profileService)
        {

            GetProfileCommand = new GetProfileCommand(profileService,this, list);
            ChangeIconCommand = new ChangeProfileIconCommand(profileService);
            ChangeBgPhotoCommand= new ChangePhotoBkProfile(profileService);
            ReloadProfileCommand=new ReloadProfileCommand(profileService,this, list); 
             GetProfileCommand.Execute(null);
            
          ChatBarView = chatBarViewModel;
          


        }
        
         public ICommand ReloadProfileCommand { get; }

        public ICommand GetProfileCommand { get; }
        public ICommand ChangeIconCommand { get; }
        public ICommand ChangeBgPhotoCommand { get; }

    }
}
