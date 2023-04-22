﻿using ClientChat_WPF_MVVM.Commands.Chat;
using ClientChat_WPF_MVVM.Models.Chat;
using ClientChat_WPF_MVVM.Services.API.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public ChatBarViewModel(IFriendService  friendService)
    {
      
        GetFriendsCommand = new GetFriendsCommand(this, friendService);
        DeleteFriendCommand = new DeleteFriendCommand(friendService, GetFriendsCommand);
        GetFriendsCommand.Execute(null);
    }
    
            public ICommand DeleteFriendCommand { get; set; }

    public ICommand GetFriendsCommand { get; set; }
}
