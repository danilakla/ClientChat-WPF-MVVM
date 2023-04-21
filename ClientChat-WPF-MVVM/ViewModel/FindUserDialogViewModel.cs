using ClientChat_WPF_MVVM.Commands.ContactModalCommands;
using ClientChat_WPF_MVVM.Models.Chat;
using ClientChat_WPF_MVVM.Services.API.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel
{
   public class FindUserDialogViewModel:ViewModelBase
    {

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;
                OnPropertyChanged("Name");
            }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        private List<Contact> _contacts;

        public List<Contact> Contacts
        {
            get { return _contacts; }
            set { _contacts = value;
            OnPropertyChanged("Contacts");
            }
        }
        public ICommand SendNotificaitonCommand { get; set; }

        public ICommand FindContactsCommand { get; set; }
        public FindUserDialogViewModel(INotificationService notificationService, IContactService contactService)
        {
            FindContactsCommand = new FindContactsCommand(contactService, this);
            SendNotificaitonCommand = new SendNotificaitonCommand(this, notificationService);
        }
    }
}
