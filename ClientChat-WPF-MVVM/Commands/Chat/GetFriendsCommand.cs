using ClientChat_WPF_MVVM.Services.API.Chat;
using ClientChat_WPF_MVVM.Utils;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.Chat;
public class GetFriendsCommand : CommandAsyncBase
{
    private readonly ChatBarViewModel _chatBarViewModel;
    private readonly IFriendService _friendService;
    private readonly IConfiguration _configuration;
    private readonly IImgService _imgService;

    public GetFriendsCommand(ChatBarViewModel chatBarViewModel, IFriendService friendService, IConfiguration configuration, IImgService imgService)
    {
        _chatBarViewModel = chatBarViewModel;
        _friendService = friendService;
        _configuration = configuration;
        _imgService = imgService;
    }
    public async override Task ExecuteAsync(object parameter)
    {

        try
        {
            var friends = await _friendService.GetFriends();
            foreach (var item in friends)
            {
                if ((item.Photo is null)||(item.Photo.Length==0))
                {
                    item.Photo = await _imgService.SetDefaultImage(_configuration["Icon"]);
                }
            }
            _chatBarViewModel.Friends = friends;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
