using ClientChat_WPF_MVVM.Commands;
using ClientChat_WPF_MVVM.HttpClintContext;
using ClientChat_WPF_MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API.Authentication;
public class AuthUserService<T>
{
    private readonly HttpConnection _httpConnection;

    public AuthUserService(HttpConnection httpConnection)
    {
        _httpConnection = httpConnection;
    }

    public async Task<T> CreateAccount(UserAuthDto userAuthDto)
    {
        return await SendData(userAuthDto, "https://localhost:7293/api/Authenticate/register");


    }

    private async Task<T> SendData(UserAuthDto userAuthDto, string uri)
    {
        try
        {
            using (var connection = _httpConnection.CreateHttpContext())
            {
                
                HttpResponseMessage response =
                     await connection.PostAsJsonAsync(uri, userAuthDto);
                response.EnsureSuccessStatusCode();
                string userInfo =
                   await response.Content.ReadAsStringAsync();
                var UserAccessToken = JsonConvert.DeserializeObject<T>(userInfo);
                return UserAccessToken;
            }
        }
        catch (Exception)
        {

            throw;
        }


    }


    public async Task<T> LoginAccount(UserAuthDto userAuthDto)
    {
        return await SendData(userAuthDto, "https://localhost:7293/api/Authenticate/login");

    }
}
