using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Models.Chat
{
    public class Message
    {
        public int Id { get; set; }

        public string MessageText { get; set; } = string.Empty;

        public DateTime Time { get; set; }

        public string FromWhom { get; set; }

    }
}
