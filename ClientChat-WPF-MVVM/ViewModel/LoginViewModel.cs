using ClientChat_WPF_MVVM.Commands;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel
{
 public   class LoginViewModel:ViewModelBase
    {


        private string _lastName;

        public string Lastname
        {
            get { return _lastName; }
            set
            {
                _lastName = value;

                OnPropertyChanged("Lastname");
            }
        }


        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
               
                OnPropertyChanged("Email");
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value;
                OnPropertyChanged("Password");

            }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; 
                OnPropertyChanged("Name");

            }
        }


        public LoginViewModel(IHost host)
        {
            ComeToChat = new TestCommand(host);
        }
        public ICommand ComeToChat { get; }

    }
}
