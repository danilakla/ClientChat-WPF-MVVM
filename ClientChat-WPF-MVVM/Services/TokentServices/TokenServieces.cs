using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Services.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.TokentServices;
public class TokenServieces
{
    private readonly IConfiguration _configuration;
    private readonly ISerialization _serializationToken;

    public TokenServieces(IConfiguration configuration, 
        ISerialization serializationToken
)
    {
        _configuration = configuration;
        _serializationToken = serializationToken;
    }

    public void SetTokenAllToken<TA,TR>(TA accessToken,TR refreshToken)
    {
        SetToken(accessToken,_configuration.GetValue<string>("pathToAccTokenJson"));
        SetToken(refreshToken, _configuration.GetValue<string>("pathToRefTokenJson"));

    }
    public  void SetToken<T>(T token,string path)
    {
        _serializationToken.Serialize(token,path);
    }
    public T GetToken<T>(string key)
    {
        return _configuration.GetValue<T>(key);
    }


}
