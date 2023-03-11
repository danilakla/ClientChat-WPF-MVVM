
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API.ChatHub
{
    public class ConnectionToChat
    {
         static  ConnectionToChat()
        {


        }

        public static HubConnection Connection { get; set; }
    }
}
