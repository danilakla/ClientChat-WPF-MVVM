using ClientChat_WPF_MVVM.Services.Serialization;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.JsonSerialization;
public class SerializationServices : ISerialization
{
    private readonly IConfiguration _configuration;

    public SerializationServices(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void Serialize<T>(T data, string path)
    {

        try
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.Serialize(stream, data);
            }

        }
        catch (Exception)
        {
            throw;
        }


    }
    public T Deserialize<T>(string k, string path)
    {
        try
        {
            using (var stream = new FileStream(path, FileMode.Open))
            {
                return JsonSerializer.Deserialize<T>(stream);
            }
        }
        catch (Exception)
        {
            throw;
        }



    }
}
