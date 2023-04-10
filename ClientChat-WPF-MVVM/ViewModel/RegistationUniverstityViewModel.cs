﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            set
            {
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
                _name = value;
                OnPropertyChanged("Name");

            }
        }
        private string _universityName;

        public string UniversityName
        {
            get { return _universityName; }
            set { _universityName = value;
                OnPropertyChanged("UniversityName");

            }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value;
                OnPropertyChanged("Address");
            }
        }

        public RegistationUniverstityViewModel()
        {

        }
    }
}