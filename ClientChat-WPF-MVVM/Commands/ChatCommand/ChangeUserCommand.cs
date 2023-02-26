using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.ChatCommand;
public class ChangeUserCommand : CommandBase
{
    private readonly ChatViewModel _chatViewModel;

    public ChangeUserCommand(ChatViewModel chatViewModel)
    {
        _chatViewModel = chatViewModel;
    }

    public override void Execute(object parameter)
    {
        _chatViewModel.IsView = false;
        _chatViewModel.ChangeUser = true;
    }
}
