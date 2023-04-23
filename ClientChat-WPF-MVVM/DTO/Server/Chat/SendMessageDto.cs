using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.DTO.Server.Chat;
public class SendMessageDto
{
    public string MessageText { get; set; }
    public DateTime TimeSendMessage { get; set; }
    public string ToWhom { get; set; }
    public string nameRoom{ get; set;   }
}
