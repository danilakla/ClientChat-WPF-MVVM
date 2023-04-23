using ClientChat_WPF_MVVM.Commands.Hub;
using ClientChat_WPF_MVVM.Services.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel
{
    public class RoomViewModel:ViewModelBase
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value;
            OnPropertyChanged("Message");
            }
        }

        public RoomViewModel(IMessageHub messageHub)
        {
            SendMessage = new SendMessageCommand(messageHub, this);
        }
        public ICommand SendMessage { get; set; }
    }
}
