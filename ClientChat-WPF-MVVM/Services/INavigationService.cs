﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services;
public interface INavigationService
{
    void NavigateToChatView();

    void NavigateToConfirmEmailView();

}
