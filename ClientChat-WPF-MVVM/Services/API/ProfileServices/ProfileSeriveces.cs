using ClientChat_WPF_MVVM.HttpClintContext;
using ClientChat_WPF_MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API.ProfileServices
{
    class ProfileSeriveces<T>
    {
        private readonly HttpConnection _httpConnection;

        public ProfileSeriveces(HttpConnection httpConnection)
        {
            _httpConnection = httpConnection;
        }
        public async Task CreateProfile(T profile)
        {
            try
            {
                using (var connection = _httpConnection.CreateHttpContext())
                {
                    HttpResponseMessage response =
                         await connection.PostAsJsonAsync($"d", profile);
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetProfile(string email)
        {
            try
            {
                using (var connection = _httpConnection.CreateHttpContext())
                {
                    HttpResponseMessage response =
                         await connection.GetAsync($"d");
                    response.EnsureSuccessStatusCode();
                    string userProfile =
                       await response.Content.ReadAsStringAsync();
                    var Profile = JsonConvert.DeserializeObject<T>(userProfile);
                    return Profile;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
