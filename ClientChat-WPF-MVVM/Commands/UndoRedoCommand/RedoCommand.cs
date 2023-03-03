using ClientChat_WPF_MVVM.Strore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.UndoRedoCommand;
public class RedoCommand : CommandBase
{
    private readonly ChatViewModel _chatViewModel;
    private readonly UndoRedoStoreStringSearch _undoRedoStoreStringSearch;

    public RedoCommand(ChatViewModel chatViewModel ,UndoRedoStoreStringSearch undoRedoStoreStringSearch )
    {
        _chatViewModel = chatViewModel;
        _undoRedoStoreStringSearch = undoRedoStoreStringSearch;
    }
    public override void Execute(object parameter)
    {
        _chatViewModel.FindFriend = _undoRedoStoreStringSearch.SearchString;
    }
}
