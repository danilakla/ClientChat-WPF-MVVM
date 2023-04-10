using ClientChat_WPF_MVVM.Commands;
using ClientChat_WPF_MVVM.Commands.PreviewCommands;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel
{
   public class NavigationPreviewViewModel:ViewModelBase
    {

        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get => _selectedViewModel;
            set { _selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        public NavigationPreviewViewModel(LoginViewModel loginViewModel, 
            RegistrationViewModel registrationViewModel,
            RegistationUniverstityViewModel registationUniverstityViewModel)
        {
            SelectedViewModel = loginViewModel;
            ToRegistrationViewCommand = new ToRegistrationViewCommand(registrationViewModel, this, loginViewModel);
            ToUniversityViewCommand = new ToUniversityViewCommand(registationUniverstityViewModel, this);
        }

        public ICommand ToUniversityViewCommand { get; }

        public ICommand ToRegistrationViewCommand { get; }

        private bool _isLogin=true;

        public bool IsLogin
        {
            get { return _isLogin; }
            set {
                _isLogin = value;
                OnPropertyChanged("IsLogin");

            }
        }

    }
}
