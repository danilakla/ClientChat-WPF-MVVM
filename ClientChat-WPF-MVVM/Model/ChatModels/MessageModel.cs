using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Model.ChatModels
{
   public class MessageModel
    {
        public string Text { get; set; }
        public string From { get; set; }
        public string imageUrl{ get; set; }
        public bool IsOwned { get; set; }


        public DateTime Time { get; set; }
    }
}
