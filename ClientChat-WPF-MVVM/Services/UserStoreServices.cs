using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Strore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services;
public class UserStoreServices
{
    private readonly UserStore _userStore;

    public UserStoreServices(UserStore userStore)
    {
        _userStore = userStore;
    }
  public  void CreateProfileLocaly(UserAuthDto user)
    {
        _userStore.User.Id =0 ;


        _userStore.User.Email = user.Username;
    }

    public UserProfileModel GetUserProfile()
    {
        return _userStore.User;

    }
}
