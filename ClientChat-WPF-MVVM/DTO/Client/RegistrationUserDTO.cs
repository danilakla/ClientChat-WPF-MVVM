
using ClientChat_WPF_MVVM.Model;

namespace ClientChat_WPF_MVVM.DTO.Client;

public class RegistrationUserDTO:UserModel
{
    public string AuthenticationToken { get; set; }
    public string Role { get; set; }

}
