using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Models.Chat
{
   public class Notification
    {
        public int Id { get; set; }
        public string MessageText { get; set; } = string.Empty;
        public string RoomName { get; set; } = string.Empty;
        public string FromWhom { get; set; } = string.Empty;

    }
}
