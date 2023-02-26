using ClientChat_WPF_MVVM.Model.ChatModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Model.Dto
{
    class SendingMessageDto
    {
        public string Text { get; set; }
        public string From { get; set; }
        public int ConversationId{ get; set; }
        public DateTime Time { get; set; }

    }
}
