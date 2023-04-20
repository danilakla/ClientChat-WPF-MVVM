using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands;
public class ToWelcomeViewCommand:CommandBase
{
    private readonly ChatRoomViewModel _welcomeChatViewModel;
    private readonly ChatNavigationViewModel _chatNavigationViewModel;

    public override void Execute(object parameter)
    {
        _chatNavigationViewModel.SelectedViewModel = _welcomeChatViewModel;
    }
    public ToWelcomeViewCommand(ChatRoomViewModel welcomeChatViewModel, ChatNavigationViewModel chatNavigationViewModel)
    {
        _welcomeChatViewModel = welcomeChatViewModel;
        _chatNavigationViewModel = chatNavigationViewModel;
    }
}
