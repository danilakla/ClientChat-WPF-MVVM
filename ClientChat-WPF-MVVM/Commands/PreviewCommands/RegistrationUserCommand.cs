using Accessibility;
using ClientChat_WPF_MVVM.DTO.Client;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ClientChat_WPF_MVVM.Commands.PreviewCommands;
public class RegistrationUserCommand : CommandAsyncBase
{
    private readonly IRegistrationService _registrationService;
    private readonly RegistrationViewModel _registrationViewModel;
    private readonly INavigationService _navigationService;

    public RegistrationUserCommand(IRegistrationService registrationService, RegistrationViewModel registrationViewModel, INavigationService navigationService)
    {
        _registrationService = registrationService;
        _registrationViewModel = registrationViewModel;
        _navigationService = navigationService;
    }
    public async override Task ExecuteAsync(object parameter)
    {
        try
        {
            
            var userData= new RegistrationUserDTO
            {
              Email=_registrationViewModel.Email,
              AuthenticationToken=_registrationViewModel.RegistrationToken,
              LastName=_registrationViewModel.Lastname,
              Name=_registrationViewModel.Name,
              Password=_registrationViewModel.Password,
              Role= _registrationViewModel.Role 
              
            };
              await _registrationService.RegistrationUser(userData);
            if (_registrationViewModel.Role == "Student")
            {
                _navigationService.NavigateToChatView();
            }
            else
            {
                _navigationService.NavigateToConfirmEmailView();
            }

        }
        catch (Exception)
        {

            throw;
        }
    }
}
