using ClientChat_WPF_MVVM.Commands.Chat;
using ClientChat_WPF_MVVM.Models.Chat;
using ClientChat_WPF_MVVM.View.UserControllers.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel
{
    public   class ChatRoomViewModel:ViewModelBase
    {
        private object _selectedRoom;
        public object SelectedRoom
        {
            get => _selectedRoom;
            set { _selectedRoom = value; OnPropertyChanged("SelectedRoom"); }
        }

        private object _chatBarView;
        public object ChatBarView
        {
            get => _chatBarView;
            set { _chatBarView = value; OnPropertyChanged("ChatBarView"); }
        }

        private Friend _friend;

        public Friend SelectedFriend
        {
            get { return _friend; }
            set { _friend = value;
                OnPropertyChanged("SelectedFriend");
            }
        }

        public ChatRoomViewModel(StartRoomViewModel startRoomViewModel, RoomViewModel roomViewModel, ChatBarViewModel chatBarViewModel)
        {
            
            _chatBarView = chatBarViewModel;
            SelectedRoom = startRoomViewModel;
            ToWelcomeViewCommand = new SelectRoomCommand(roomViewModel, this);
        }
        public ICommand ToWelcomeViewCommand { get; set; }
    }
}
