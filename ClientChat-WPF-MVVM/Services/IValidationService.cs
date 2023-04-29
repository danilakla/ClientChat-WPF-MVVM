using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services
{
    public interface IValidationService
    {
        bool HasValidEmail(string email);
        bool HasValidPassword(string password);
        bool HasEmptyValue(params string[] list);

        
    }
}
