using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Utils;
public class ImgService : IImgService
{
    public async Task<byte[]> SetDefaultImage(string path)
    {
        try
        {
            using (var str = new FileStream(path, FileMode.Open))
            {
                byte[] arr = new byte[str.Length];

                await str.ReadAsync(arr, default);
                return arr;


            }
        }
        catch (Exception)
        {

            throw;
        }



    }
}
