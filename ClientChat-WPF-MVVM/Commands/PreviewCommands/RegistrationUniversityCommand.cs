using ClientChat_WPF_MVVM.DTO.Client;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API;
using ClientChat_WPF_MVVM.View.UserControllers;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM.Commands.PreviewCommands;
internal class RegistrationUniversityCommand : CommandAsyncBase
{
    private readonly IRegistrationService _registrationService;
    private readonly RegistationUniverstityViewModel _registationUniverstityViewModel;
    private readonly INavigationService _navigationService;
    private readonly IValidationService _validationService;

    public RegistrationUniversityCommand(
        IRegistrationService registrationService, 
        RegistationUniverstityViewModel  registationUniverstityViewModel,
       INavigationService navigationService,
       IValidationService validationService
        )
    {
        _registrationService = registrationService;
        _registationUniverstityViewModel = registationUniverstityViewModel;
        _navigationService = navigationService;
        _validationService = validationService;
    }
    public override async Task ExecuteAsync(object parameter)
    {
        try
        {
            _registationUniverstityViewModel.IsVisibleSpiner = Visibility.Visible;
            var universityManager = new CreateUniversityDTO
            {
                Address = _registationUniverstityViewModel.Address,
                Email = _registationUniverstityViewModel.Email,
                LastName = _registationUniverstityViewModel.Lastname,
                Name = _registationUniverstityViewModel.Name,
                NameOfUniversity = _registationUniverstityViewModel.UniversityName,
                Password = _registationUniverstityViewModel.Password
            };

            if (_validationService.HasEmptyValue(universityManager.Email,
                universityManager.Password,
                universityManager.NameOfUniversity,
                universityManager.Address,
                universityManager.LastName,
                universityManager.Name
                ))
            {
                _registationUniverstityViewModel.IsVisibleError = Visibility.Visible;
                _registationUniverstityViewModel.Error = "There is some empty value";
                throw new Exception("999");
            }

            if (!_validationService.HasValidPassword(_registationUniverstityViewModel.Password))
            {
                _registationUniverstityViewModel.IsVisibleError = Visibility.Visible;
                _registationUniverstityViewModel.Error = "Unvalid Password";
                throw new Exception("999");

            }

            if (!_validationService.HasValidEmail(_registationUniverstityViewModel.Email))
            {
                _registationUniverstityViewModel.IsVisibleError = Visibility.Visible;
                _registationUniverstityViewModel.Error = "Unvalid Email";
                throw new Exception("999");

            }
            await _registrationService.RegistrationUniversity(universityManager);
            _registationUniverstityViewModel.IsVisibleSpiner = Visibility.Collapsed;

            _navigationService.NavigateToConfirmEmailView();

        }
        catch (Exception e)
        {
            _registationUniverstityViewModel.IsVisibleSpiner = Visibility.Collapsed;


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
