using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM.Commands
{
    public class OpenFindUserDialogCommand : CommandBase
    {
        private readonly ChatNavigationViewModel _chatNavigationViewModel;

        public OpenFindUserDialogCommand(ChatNavigationViewModel chatNavigationViewModel)
        {
            _chatNavigationViewModel = chatNavigationViewModel;
        }
        public override void Execute(object parameter)
        {
            if (_chatNavigationViewModel.VisibilityFindUserModal==Visibility.Collapsed)
            {
                _chatNavigationViewModel.VisibilityFindUserModal=Visibility.Visible;
            }
            else
            {
                _chatNavigationViewModel.VisibilityFindUserModal = Visibility.Collapsed;

            }


        }
    }
}
