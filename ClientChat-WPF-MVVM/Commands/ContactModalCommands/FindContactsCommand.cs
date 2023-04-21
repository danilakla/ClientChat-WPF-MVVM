using ClientChat_WPF_MVVM.Services.API.Chat;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.ContactModalCommands;
internal class FindContactsCommand : CommandAsyncBase
{
    private readonly IContactService _contactService;
    private readonly FindUserDialogViewModel _findUserDialogViewModel;

    public FindContactsCommand(IContactService contactService,
        FindUserDialogViewModel findUserDialogViewModel)
    {
        _contactService = contactService;
        _findUserDialogViewModel = findUserDialogViewModel;
    }
    public async override Task ExecuteAsync(object parameter)
    {
        var name=_findUserDialogViewModel.Name;
        var lastName=_findUserDialogViewModel.LastName;
        var contacts = await _contactService.GetContacts(name,lastName);
        if(contacts is not null)
        {
            _findUserDialogViewModel.Contacts=contacts;
        }
    }
}
