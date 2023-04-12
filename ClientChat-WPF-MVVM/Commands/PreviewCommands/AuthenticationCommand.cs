using ClientChat_WPF_MVVM.DTO.Client;
using ClientChat_WPF_MVVM.DTO.Server;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.PreviewCommands;
public class AuthenticationCommand : CommandAsyncBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly LoginViewModel _loginViewModel;
    private readonly INavigationService _navigationService;

    public AuthenticationCommand(IAuthenticationService authenticationService, LoginViewModel loginViewModel, INavigationService navigationService)
    {
        _authenticationService = authenticationService;
        _loginViewModel = loginViewModel;
        _navigationService = navigationService;
    }
    public override async Task ExecuteAsync(object parameter)
    {
        try
        {
            var userData = new AuthDto
            {
              Email= _loginViewModel.Email,
              Password=_loginViewModel.Password

            };
           await _authenticationService.LoginUser(userData);
           
                _navigationService.NavigateToChatView();
        

        }
        catch (Exception)
        {

            throw;
        }
    }
}
