using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Model.Dto
{
    public class AddFriendDto
    {
        public int UserId { get; set; }
        public string EmailOfFriend { get; set; }
    }
}
