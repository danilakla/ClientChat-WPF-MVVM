﻿using ClientChat_WPF_MVVM.Models.Chat;
using ClientChat_WPF_MVVM.Services.API.Chat;
using ClientChat_WPF_MVVM.View.UserControllers;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM.Commands.Chat;
public class SelectRoomCommand : CommandAsyncBase
{
    private readonly RoomViewModel _roomViewModel;
    private readonly ChatRoomViewModel _chatRoomViewModel;
    private readonly IChatService _chatService;

    public SelectRoomCommand(RoomViewModel roomViewModel, ChatRoomViewModel chatRoomViewModel, IChatService chatService)
    {
        _roomViewModel = roomViewModel;
        _chatRoomViewModel = chatRoomViewModel;
        _chatService = chatService;
    }
    public async override Task ExecuteAsync(object parameter)
    {
        try
        {
            if (_chatRoomViewModel.SelectedFriend is not null)
            {
var messages = await _chatService.GetMessages(_chatRoomViewModel.SelectedFriend.ConversationName);
            if (messages is not null)
            {
                _chatRoomViewModel.Messages = new ObservableCollection<Message>(messages);

            }
            _chatRoomViewModel.SelectedRoom = _roomViewModel;
            }
            

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
