using ClientChat_WPF_MVVM.Strore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.UndoRedoCommand;
public class UndoCommand:CommandBase
{
    private readonly ChatViewModel _chatViewModel;
    private readonly UndoRedoStoreStringSearch _undoRedoStoreStringSearch;

    public UndoCommand(ChatViewModel chatViewModel, UndoRedoStoreStringSearch undoRedoStoreStringSearch)
    {
        _chatViewModel = chatViewModel;
        _undoRedoStoreStringSearch = undoRedoStoreStringSearch;
    }
    public override void Execute(object parameter)
    {
        _undoRedoStoreStringSearch.SearchString=_chatViewModel.FindFriend;
        _chatViewModel.FindFriend = "";
    }
}
