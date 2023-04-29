using ClientChat_WPF_MVVM.Commands;
using ClientChat_WPF_MVVM.Commands.PreviewCommands;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel
{
    public   class LoginViewModel:ViewModelBase
    {


    

        private string _email= "sany@mail.ru";

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
               
                OnPropertyChanged("Email");
            }
        }

        private string _password= "Yyyytyt867++";

        public string Password
        {
            get { return _password; }
            set { _password = value;
                OnPropertyChanged("Password");

            }
        }
        private Visibility _visibility= Visibility.Collapsed;
        public Visibility IsVisibleSpiner
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged("IsVisibleSpiner");

            }
        }


        
        public LoginViewModel(IAuthenticationService authenticationService, INavigationService navigationService)
        {

            AuthenticationCommand = new AuthenticationCommand(authenticationService, this , navigationService);
        }
        public ICommand AuthenticationCommand { get; set; }


    }
}
