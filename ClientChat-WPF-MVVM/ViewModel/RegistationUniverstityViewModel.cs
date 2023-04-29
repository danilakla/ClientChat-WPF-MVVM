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
    public  class RegistationUniverstityViewModel:ViewModelBase
    {
        private string _lastName;

        public string Lastname
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                IsVisibleError=Visibility.Collapsed;
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
                IsVisibleError = Visibility.Collapsed;

                OnPropertyChanged("Email");
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                IsVisibleError = Visibility.Collapsed;

                OnPropertyChanged("Password");

            }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                IsVisibleError = Visibility.Collapsed;

                OnPropertyChanged("Name");

            }
        }
        private string _universityName;

        public string UniversityName
        {
            get { return _universityName; }
            set { _universityName = value;
                IsVisibleError = Visibility.Collapsed;

                OnPropertyChanged("UniversityName");

            }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value;
                IsVisibleError = Visibility.Collapsed;
                OnPropertyChanged("Address");
            }
        }
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
        public RegistationUniverstityViewModel(IRegistrationService registrationService, 
            INavigationService navigationService,
            IValidationService validationService)
        {
            RegistrationUniversityCommand = new RegistrationUniversityCommand(registrationService,this, navigationService, validationService);
        }
        public ICommand RegistrationUniversityCommand { get; }
    }
}
