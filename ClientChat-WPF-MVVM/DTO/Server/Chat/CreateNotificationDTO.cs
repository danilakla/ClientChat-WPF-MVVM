using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.DTO.Server.Chat
{
    public class CreateNotificationDTO
    {
        public int FriendId { get; set; }
        public string MessageBody { get; set; }
        public string FromWhom { get; set; }
    }
}
