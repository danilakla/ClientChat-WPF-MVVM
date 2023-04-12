using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services;
public interface ISerialization
{
    void Serialize<T>(T data, string path);
    T Deserialize<T>(string path);
}
