using ClientChat_WPF_MVVM.DTO.Client;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.PreviewCommands;
internal class RegistrationUniversityCommand : CommandAsyncBase
{
    private readonly IRegistrationService _registrationService;
    private readonly RegistationUniverstityViewModel _registationUniverstityViewModel;
    private readonly INavigationService _navigationService;

    public RegistrationUniversityCommand(
        IRegistrationService registrationService, 
        RegistationUniverstityViewModel  registationUniverstityViewModel,
       INavigationService navigationService
        )
    {
        _registrationService = registrationService;
        _registationUniverstityViewModel = registationUniverstityViewModel;
        _navigationService = navigationService;
    }
    public override async Task ExecuteAsync(object parameter)
    {
        try
        {
            var universityManager = new CreateUniversityDTO
            {
                Address = _registationUniverstityViewModel.Address,
                Email = _registationUniverstityViewModel.Email,
                LastName = _registationUniverstityViewModel.Lastname,
                Name = _registationUniverstityViewModel.Name,
                NameOfUniversity = _registationUniverstityViewModel.UniversityName,
                Password = _registationUniverstityViewModel.Password
            };
            await _registrationService.RegistrationUniversity(universityManager);
            _navigationService.NavigateToConfirmEmailView();

        }
        catch (Exception)
        {

            throw;
        }
     
    }
}
