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
                IsVisibleError = Visibility.Collapsed;

                OnPropertyChanged("Email");
            }
        }

        private string _password= "Yyyytyt867++";

        public string Password
        {
            get { return _password; }
            set { _password = value;
                IsVisibleError=Visibility.Collapsed;
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
        private string _error;

        public string Error
        {
            get { return _error; }
            set
            {
                _error = value;
                OnPropertyChanged("Error");

            }
        }
        private Visibility _visibilityError = Visibility.Collapsed;
        public Visibility IsVisibleError
        {
            get { return _visibilityError; }
            set
            {
                _visibilityError = value;
                OnPropertyChanged("IsVisibleError");

            }
        }





        public LoginViewModel(IAuthenticationService authenticationService, INavigationService navigationService, IValidationService validationService)
        {

            AuthenticationCommand = new AuthenticationCommand(authenticationService, this , navigationService, validationService);
        }
        public ICommand AuthenticationCommand { get; set; }


    }
}
