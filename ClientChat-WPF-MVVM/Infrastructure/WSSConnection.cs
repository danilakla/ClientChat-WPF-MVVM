using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Infrastructure;
public class WSSConnection
{
    public WSSConnection(Func<HubConnection> hubConnection)
    {
        Connection= hubConnection();
    }
    public  HubConnection Connection { get;  }
}
