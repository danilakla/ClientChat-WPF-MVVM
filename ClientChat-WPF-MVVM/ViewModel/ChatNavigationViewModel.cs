using ClientChat_WPF_MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel
{
   public class ChatNavigationViewModel:ViewModelBase
    {

        private Visibility _visibilityFindUserModal= Visibility.Collapsed;
        public Visibility VisibilityFindUserModal
        {
            get => _visibilityFindUserModal;
            set { _visibilityFindUserModal = value; OnPropertyChanged("VisibilityFindUserModal"); }
        }


        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get => _selectedViewModel;
            set { _selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }
        private object _findUserDialog;
        public object FindUserDialog
        {
            get => _findUserDialog;
            set { _findUserDialog = value; OnPropertyChanged("FindUserDialog"); }
        }

        public ChatNavigationViewModel(WelcomeChatViewModel welcomeChatViewModel, ProfileViewModel profileViewModel, ChatRoomViewModel chatRoom,
            FindUserDialogViewModel findUserDialogViewModel)
        {
            FindUserDialog = findUserDialogViewModel;
            SelectedViewModel = welcomeChatViewModel;
            ToProfileView = new ToProfileViewCommand(profileViewModel, this);
            ToWelcomeViewCommand = new ToWelcomeViewCommand(chatRoom, this);
            OpenDialogFindUser=new OpenFindUserDialogCommand(this);
        }

        public ICommand OpenDialogFindUser { get; }

        public ICommand ToProfileView { get; }
        public ICommand ToWelcomeViewCommand { get; }

        
    }
}
