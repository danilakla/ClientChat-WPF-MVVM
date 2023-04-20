using ClientChat_WPF_MVVM.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.API.Chat
{
    interface IContactService
    {
        Task<List<Contact>> GetContacts(string name, string lastName);
    }
}
