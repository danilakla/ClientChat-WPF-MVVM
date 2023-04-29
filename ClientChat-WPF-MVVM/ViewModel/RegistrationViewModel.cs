using ClientChat_WPF_MVVM.Commands.PreviewCommands;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel
{
    public class RegistrationViewModel:ViewModelBase
    {

        private Visibility _visibility = Visibility.Collapsed;
        public Visibility IsVisibleSpiner
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged("IsVisibleSpiner");

            }
        }

        private string _lastName;

        public string Lastname
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                IsVisibleError = Visibility.Collapsed;

                OnPropertyChanged("Lastname");
            }
        }


        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                IsVisibleError = Visibility.Collapsed;

                _email = value;

                OnPropertyChanged("Email");
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                IsVisibleError = Visibility.Collapsed;

                _password = value;
                OnPropertyChanged("Password");

            }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                IsVisibleError = Visibility.Collapsed;

                _name = value;
                OnPropertyChanged("Name");

            }
        }
        private string _role;

        public string Role
        {
            get { return _role; }
            set
            {
                IsVisibleError = Visibility.Collapsed;

                _role = value.Split(": ")[1];
                OnPropertyChanged("Role");

            }
        }


        private string _registrationToken;

        public string RegistrationToken
        {
            get { return _registrationToken; }
            set { _registrationToken = value;
                IsVisibleError=Visibility.Collapsed;
                OnPropertyChanged("RegistrationToken");

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
        public RegistrationViewModel(IRegistrationService registrationService, INavigationService navigationService, IValidationService validationService)
        {
            RegistrationUserCommand = new RegistrationUserCommand(registrationService, this,navigationService, validationService);
        }
        public ICommand RegistrationUserCommand { get; set; }
    }
}
