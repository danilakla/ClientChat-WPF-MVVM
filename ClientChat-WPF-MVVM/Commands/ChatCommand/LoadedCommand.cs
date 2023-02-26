using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Model.ChatModels;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API.Authentication;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands;
public class LoadedCommand : CommandAsyncBase
{
    private readonly ChatViewModel _chatViewModel;
    private readonly UserStoreServices _userStoreServices;

    public LoadedCommand(ChatViewModel chatViewModel, UserStoreServices userStoreServices)
    {
        _chatViewModel = chatViewModel;
        _userStoreServices = userStoreServices;
    }

    public async override Task ExecuteAsync(object parameter)
    {
        
        var user = _userStoreServices.GetUserProfile();
        user.profileImage = "https://i.imgur.com/UcFmWTI.jpeg";
        _chatViewModel.User = user;
        _chatViewModel.Conversations = new ObservableCollection<ConversationModel>()
        {
            new ConversationModel()
            {
                Id=0,
                FriendProfile=new UserProfileModel
                {
                    Id=1,
                    profileImage="https://i.imgur.com/ABwifID.gif",
                    Email="first email",
                    Name="first name"
                }
            },
            new ConversationModel()
            {
                Id=1,
                FriendProfile=new UserProfileModel
                {
                    Id=2,
                                        profileImage="https://i.imgur.com/cdHnutz.jpeg",

                    Email="second email",
                    Name="second name"
                }
            },

        };


    }
    private async Task cd()
    {
        while(true) { }
    }
}
