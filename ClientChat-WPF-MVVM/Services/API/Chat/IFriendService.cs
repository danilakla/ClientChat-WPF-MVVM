﻿using ClientChat_WPF_MVVM.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API.Chat
{
    public interface IFriendService
    {
        Task<List<Friend>> GetFriends();
        Task AddFriend(int idNotification);

        Task DeleteFriend(string ConversationName);

    }
}
