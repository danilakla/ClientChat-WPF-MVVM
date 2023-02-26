using ClientChat_WPF_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Strore;
public class UserStore
{
    public UserStore(UserProfileModel user)
    {
        User = user;
    }

    public UserProfileModel User { get; set; }
    
  
}
