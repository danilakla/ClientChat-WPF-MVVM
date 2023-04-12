using ClientChat_WPF_MVVM.DTO.Client;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API;

public interface IRegistrationService
{
    Task RegistrationUniversity(CreateUniversityDTO createUniversityDTO);

    Task RegistrationUser(RegistrationUserDTO createUniversityDTO);

}
