﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Utils;
public interface IImgService
{
    Task<byte[]> SetDefaultImage(string path);
}
