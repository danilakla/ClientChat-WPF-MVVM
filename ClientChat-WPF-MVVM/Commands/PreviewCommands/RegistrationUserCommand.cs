using Accessibility;
using ClientChat_WPF_MVVM.DTO.Client;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API;
using ClientChat_WPF_MVVM.View.UserControllers;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace ClientChat_WPF_MVVM.Commands.PreviewCommands;
public class RegistrationUserCommand : CommandAsyncBase
{
    private readonly IRegistrationService _registrationService;
    private readonly RegistrationViewModel _registrationViewModel;
    private readonly INavigationService _navigationService;
    private readonly IValidationService _validationService;

    public RegistrationUserCommand(IRegistrationService registrationService, RegistrationViewModel registrationViewModel, INavigationService navigationService, IValidationService validationService)
    {
        _registrationService = registrationService;
        _registrationViewModel = registrationViewModel;
        _navigationService = navigationService;
        _validationService = validationService;
    }
    public async override Task ExecuteAsync(object parameter)
    {
        try
        {
            _registrationViewModel.IsVisibleSpiner = Visibility.Visible;
            var userData= new RegistrationUserDTO
            {
              Email=_registrationViewModel.Email,
              AuthenticationToken=_registrationViewModel.RegistrationToken,
              LastName=_registrationViewModel.Lastname,
              Name=_registrationViewModel.Name,
              Password=_registrationViewModel.Password,
              Role= _registrationViewModel.Role 
              
            };

            if (_validationService.HasEmptyValue(userData.Email, 
                userData.Password,
                userData.Name,
                userData.LastName,
                userData.Role,
                userData.AuthenticationToken
                ))
            {
                _registrationViewModel.IsVisibleError = Visibility.Visible;
                _registrationViewModel.Error = "There is some empty value";
                throw new Exception("999");
            }

            if (!_validationService.HasValidPassword(userData.Password))
            {
                _registrationViewModel.IsVisibleError = Visibility.Visible;
                _registrationViewModel.Error = "Unvalid Password";
                throw new Exception("999");

            }

            if (!_validationService.HasValidEmail(userData.Email))
            {
                _registrationViewModel.IsVisibleError = Visibility.Visible;
                _registrationViewModel.Error = "Unvalid Email";
                throw new Exception("999");

            }
            await _registrationService.RegistrationUser(userData);
            _registrationViewModel.IsVisibleSpiner = Visibility.Collapsed;

            if (_registrationViewModel.Role == "Student")
            {
                _navigationService.NavigateToChatView();
            }
            else
            {
                _navigationService.NavigateToConfirmEmailView();
            }

        }
        catch (Exception e)
        {
            _registrationViewModel.IsVisibleSpiner = Visibility.Collapsed;


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
