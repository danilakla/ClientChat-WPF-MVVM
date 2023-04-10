using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands
{
    public class ToProfileViewCommand : CommandBase
    {
        private readonly ProfileViewModel _profileViewModel;
        private readonly ChatNavigationViewModel _chatNavigationViewModel;

        public override void Execute(object parameter)
        {
        _chatNavigationViewModel.SelectedViewModel= _profileViewModel;
        }
        public ToProfileViewCommand( ProfileViewModel profileViewModel, ChatNavigationViewModel chatNavigationViewModel)
        {
            _profileViewModel = profileViewModel;
            _chatNavigationViewModel = chatNavigationViewModel;
        }
    }
}
