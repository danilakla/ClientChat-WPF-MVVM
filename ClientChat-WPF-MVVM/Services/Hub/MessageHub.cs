using ClientChat_WPF_MVVM.DTO.Server.Chat;
using ClientChat_WPF_MVVM.Infrastructure;
using ClientChat_WPF_MVVM.Models.Chat;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace ClientChat_WPF_MVVM.Services.Hub;
public class MessageHub : IMessageHub
{
    private readonly WSSConnection _wSSConnection;

    public MessageHub(WSSConnection wSSConnection)
    {
        _wSSConnection = wSSConnection;
    }
    public async Task AwaitMessage(ChatRoomViewModel _chatRoomViewModel)
    {

        try
        {
             _wSSConnection.Connection.On<Message>("ReceiveMessage", (msg) => {

                 if (_chatRoomViewModel.SelectedFriend is not null)
                 {
                     if ((msg.FromWhom != _chatRoomViewModel.SelectedFriend.Email)&& (msg.FromWhom !=UserStore.Email))
                     {
                         return;
                     }
                     _chatRoomViewModel.Messages.Add(msg);
                 }
             });
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task SendMessage(SendMessageDto sendMessageDto)
    {
        try
        {
            await _wSSConnection.Connection.InvokeAsync("SendMessage", sendMessageDto);

        }
        catch (Exception)
        {

            throw;
        }
    }
}
