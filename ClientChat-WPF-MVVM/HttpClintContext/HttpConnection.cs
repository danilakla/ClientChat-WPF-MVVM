using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.HttpClintContext;
public class HttpConnection
{
    public string ServerUrl { get; set; }
    public HttpConnection(string url)
    {
        ServerUrl = url;
    }
    public  HttpClient CreateHttpContext()
    {

        return  new HttpClient();
    }
}
