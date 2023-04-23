using ClientChat_WPF_MVVM.DTO.Server.Chat;
using ClientChat_WPF_MVVM.Models.Chat;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.Hub;
public interface IMessageHub
{
    Task SendMessage(SendMessageDto sendMessageDto);
    Task AwaitMessage(ChatRoomViewModel chatRoomViewModel);
}
