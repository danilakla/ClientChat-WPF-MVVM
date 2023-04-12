using ClientChat_WPF_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.TokenService;
 public  interface ITokenService
{
    void SetTokens(JwtTokens jwtTokens);
    JwtTokens GetTokens();
  
}
