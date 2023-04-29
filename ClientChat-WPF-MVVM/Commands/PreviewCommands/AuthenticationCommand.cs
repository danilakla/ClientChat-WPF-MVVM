using ClientChat_WPF_MVVM.DTO.Client;
using ClientChat_WPF_MVVM.DTO.Server;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API;
using ClientChat_WPF_MVVM.View.UserControllers;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClientChat_WPF_MVVM.Commands.PreviewCommands;
public class AuthenticationCommand : CommandAsyncBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly LoginViewModel _loginViewModel;
    private readonly INavigationService _navigationService;
    private readonly IValidationService _validationService;

    public AuthenticationCommand(IAuthenticationService authenticationService, LoginViewModel loginViewModel, INavigationService navigationService, IValidationService validationService)
    {
        _authenticationService = authenticationService;
        _loginViewModel = loginViewModel;
        _navigationService = navigationService;
        _validationService = validationService;
    }
    public override async Task ExecuteAsync(object parameter)
    {
        try
        {


            _loginViewModel.IsVisibleSpiner = Visibility.Visible;
            var userData = new AuthDto
            {
                Email = _loginViewModel.Email,
                Password = _loginViewModel.Password

            };
            if (_validationService.HasEmptyValue(userData.Email, userData.Password))
            {
                _loginViewModel.IsVisibleError = Visibility.Visible;
                _loginViewModel.Error = "There is some empty value";
                throw new Exception("999");
            }

            if (!_validationService.HasValidPassword(userData.Password))
            {
                _loginViewModel.IsVisibleError = Visibility.Visible;
                _loginViewModel.Error = "Unvalid Password";
                throw new Exception("999");

            }

            if (!_validationService.HasValidEmail(userData.Email))
            {
                _loginViewModel.IsVisibleError = Visibility.Visible;
                _loginViewModel.Error = "Unvalid Email";
                throw new Exception("999");

            }
            await _authenticationService.LoginUser(userData);
            
            _loginViewModel.IsVisibleSpiner = Visibility.Collapsed;

            _navigationService.NavigateToChatView();
        

        }
        catch (Exception e)
        {
            _loginViewModel.IsVisibleSpiner = Visibility.Collapsed;

            if (!e.Message.Contains("999"))
            {
                Window window = new Window
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Width = 300,
                    Height = 200,
                    Title = "Error",
                    Content = new Reject()
                };
                window.ShowDialog();
            }
        

         
        }
    }
}
