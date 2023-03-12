using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Model.ChatModels
{
   public class ConversationModel
    {
        public int Id { get; set; }
        public UserProfileModel FriendProfile { get; set; }
        public List<MessageModel> MessageModels { get; set; } = new();
    }
}
