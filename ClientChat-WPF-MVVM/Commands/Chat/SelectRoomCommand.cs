using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.Chat;
public class SelectRoomCommand : CommandAsyncBase
{
    private readonly RoomViewModel _roomViewModel;
    private readonly ChatRoomViewModel _chatRoomViewModel;

    public SelectRoomCommand(RoomViewModel roomViewModel, ChatRoomViewModel chatRoomViewModel)
    {
        _roomViewModel = roomViewModel;
        _chatRoomViewModel = chatRoomViewModel;
    }
    public async override Task ExecuteAsync(object parameter)
    {
        _chatRoomViewModel.SelectedRoom = _roomViewModel;
    }

}
