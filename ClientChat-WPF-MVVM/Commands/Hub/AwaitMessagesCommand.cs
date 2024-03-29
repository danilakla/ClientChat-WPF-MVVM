﻿using ClientChat_WPF_MVVM.Services.Hub;
using ClientChat_WPF_MVVM.View.UserControllers;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM.Commands.Hub;
public class AwaitMessagesCommand : CommandAsyncBase
{
    private readonly IMessageHub _messageHub;
    private readonly ChatRoomViewModel _chatRoomViewModel;

    public AwaitMessagesCommand(IMessageHub messageHub, ChatRoomViewModel chatRoomViewModel)
    {
        _messageHub = messageHub;
        _chatRoomViewModel = chatRoomViewModel;
    }
    public async override Task ExecuteAsync(object parameter)
    {
        try
        {
           await _messageHub.AwaitMessage(_chatRoomViewModel);
          
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
