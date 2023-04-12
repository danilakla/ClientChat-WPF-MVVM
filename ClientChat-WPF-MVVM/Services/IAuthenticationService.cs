

using ClientChat_WPF_MVVM.DTO.Server;
using ClientChat_WPF_MVVM.Model;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services;

public interface IAuthenticationService
{
   Task<JwtTokens> LoginUser(AuthDto userModel);
}
