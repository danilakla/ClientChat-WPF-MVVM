using ClientChat_WPF_MVVM.Commands.Chat;
using ClientChat_WPF_MVVM.Models.Chat;
using ClientChat_WPF_MVVM.Services.API.Chat;
using ClientChat_WPF_MVVM.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel;
public class ChatBarViewModel:ViewModelBase
{
    private List<Friend> _friends;

    public List<Friend> Friends
    {
        get { return _friends; }
        set { _friends = value;
            OnPropertyChanged("Friends");
        }
    }
    private Visibility _visibility = Visibility.Collapsed;
    public Visibility IsVisibleSpiner
    {
        get { return _visibility; }
        set
        {
            _visibility = value;
            OnPropertyChanged("IsVisibleSpiner");

        }
    }
    public ChatBarViewModel(IFriendService  friendService, IConfiguration configuration, IImgService imgService)
    {
      
        GetFriendsCommand = new GetFriendsCommand(this, friendService, configuration, imgService);
        DeleteFriendCommand = new DeleteFriendCommand(friendService, GetFriendsCommand);
        ReloadFriendCommand = new GetFriendsCommand(this, friendService, configuration, imgService);
        GetFriendsCommand.Execute(null);
    }
    public ICommand ReloadFriendCommand    { get; set; }

    public ICommand DeleteFriendCommand { get; set; }
    public ICommand GetFriendsCommand { get; set; }
}
