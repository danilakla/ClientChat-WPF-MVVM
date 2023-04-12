using ClientChat_WPF_MVVM.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.TokenService;
public class TokenService:ITokenService
{
    private readonly ISerialization _serialization;
    private readonly IConfiguration _configuration;

    public TokenService(ISerialization serialization, IConfiguration configuration)
    {
        _serialization = serialization;
        _configuration = configuration;
    }

    public JwtTokens GetTokens()
    {
      return _serialization.Deserialize<JwtTokens>(_configuration["JwtTokensPath"]);
    }

  
    public void SetTokens(JwtTokens jwtTokens)
    {
        _serialization.Serialize(jwtTokens, _configuration["JwtTokensPath"]);

    }
}
