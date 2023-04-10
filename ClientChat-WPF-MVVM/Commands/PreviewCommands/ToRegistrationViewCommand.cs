using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.PreviewCommands
{
    class ToRegistrationViewCommand : CommandBase
    {
        private readonly RegistrationViewModel _registrationViewModel;
        private readonly NavigationPreviewViewModel _navigationPreviewViewModel;
        private readonly LoginViewModel _loginViewModel;

        public ToRegistrationViewCommand(RegistrationViewModel registrationViewModel, 
            NavigationPreviewViewModel navigationPreviewViewModel, LoginViewModel loginViewModel)
        {
            _registrationViewModel = registrationViewModel;
       
            _navigationPreviewViewModel = navigationPreviewViewModel;
            _loginViewModel = loginViewModel;
        }
        public override void Execute(object parameter)
        {
            if (_navigationPreviewViewModel.IsLogin == true)
            {
                _navigationPreviewViewModel.SelectedViewModel = _registrationViewModel;
                

            }
            else
            {
                _navigationPreviewViewModel.SelectedViewModel = _loginViewModel;

            }
            _navigationPreviewViewModel.IsLogin = !_navigationPreviewViewModel.IsLogin;
        }
    }
}
