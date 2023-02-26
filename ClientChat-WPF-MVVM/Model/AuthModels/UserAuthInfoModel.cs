using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Model;
public class UserAuthInfoModel
{
    public AccessToken AccToken { get; set; }
    public RefreshToken RefToken { get; set; }

}

