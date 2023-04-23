using ClientChat_WPF_MVVM.Models.Chat;
using ClientChat_WPF_MVVM.Services.API.Chat;
using ClientChat_WPF_MVVM.Utils;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.Extensions.Configuration;
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
    private readonly IConfiguration _configuration;
    private readonly IImgService _imgService;

    public FindContactsCommand(IContactService contactService,
        FindUserDialogViewModel findUserDialogViewModel,
        IConfiguration configuration, IImgService imgService)
    {
        _contactService = contactService;
        _findUserDialogViewModel = findUserDialogViewModel;
        _configuration = configuration;
        _imgService = imgService;
    }
    public async override Task ExecuteAsync(object parameter)
    {
        var name=_findUserDialogViewModel.Name;
        var lastName=_findUserDialogViewModel.LastName;
        var contacts = await _contactService.GetContacts(name,lastName);
        if(contacts is not null)
        {
            foreach (var item in contacts)
            {
                if ((item.Photo is null) || (item.Photo.Length == 0))
                {
                    item.Photo = await _imgService.SetDefaultImage(_configuration["Icon"]);
                }
            }
            _findUserDialogViewModel.Contacts=contacts;
        }
    }
}
