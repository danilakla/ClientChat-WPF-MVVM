using ClientChat_WPF_MVVM.DTO.Server.Chat;
using ClientChat_WPF_MVVM.Models.Chat;
using ClientChat_WPF_MVVM.Services.Hub;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.Hub;
public class SendMessageCommand : CommandAsyncBase
{
    private readonly IMessageHub _messageHub;
    private readonly RoomViewModel _roomViewModel;

    public SendMessageCommand(IMessageHub messageHub, RoomViewModel roomViewModel)
    {
        _messageHub = messageHub;
        _roomViewModel = roomViewModel;
    }
    public async override Task ExecuteAsync(object parameter)
    {
        try
        {
   Friend friend=parameter as Friend;

        var msg = new SendMessageDto() { MessageText=_roomViewModel.Message,
            ToWhom=friend.Email, 
            nameRoom=friend.ConversationName, 
            TimeSendMessage=DateTime.Now,};
            await _messageHub.SendMessage(msg);
        }
        catch (Exception)
        {

            throw;
        }
     
      
    }
}
