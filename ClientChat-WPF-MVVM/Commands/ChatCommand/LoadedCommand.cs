using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Model.ChatModels;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API.Authentication;
using ClientChat_WPF_MVVM.Services.API.ChatSerivices;
using ClientChat_WPF_MVVM.Services.API.ProfileServices;
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
    private readonly ChatServices _chatServices;

    public LoadedCommand(ChatViewModel chatViewModel, UserStoreServices userStoreServices, ChatServices chatServices)
    {
        _chatViewModel = chatViewModel;
        _userStoreServices = userStoreServices;
        _chatServices = chatServices;
    }

    public async override Task ExecuteAsync(object parameter)
    {

        var user = _userStoreServices.GetUserProfile();
        user.profileImage = "https://i.imgur.com/UcFmWTI.jpeg";
        _chatViewModel.User = user;
        var friends = await _chatServices.LoadFriends(_chatViewModel);
        ObservableCollection<ConversationModel> listOfFriend = new();

        if (friends is not null)
        {
            foreach (var friend in friends)
            {
                _chatViewModel.Conversations.Add(new ConversationModel { Id = 0, FriendProfile = new UserProfileModel { Id = 0, profileImage = "", Email = friend.Name, Name = friend.Name } });
            }
        }


    }

}
