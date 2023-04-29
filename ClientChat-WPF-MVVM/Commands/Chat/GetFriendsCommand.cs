using ClientChat_WPF_MVVM.Services.API.Chat;
using ClientChat_WPF_MVVM.Utils;
using ClientChat_WPF_MVVM.View.UserControllers;
using ClientChat_WPF_MVVM.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            _chatBarViewModel.IsVisibleSpiner = System.Windows.Visibility.Visible;
            await Task.Delay(2000);

            var friends = await _friendService.GetFriends();
            foreach (var item in friends)
            {
                if ((item.Photo is null)||(item.Photo.Length==0))
                {
                    item.Photo = await _imgService.SetDefaultImage(_configuration["Icon"]);
                }
            }
            _chatBarViewModel.Friends = friends;
            _chatBarViewModel.IsVisibleSpiner = System.Windows.Visibility.Collapsed;

        }
        catch (Exception e)
        {


            Window window = new Window
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 300,
                Height = 200,
                Title = "Error",
                Content = new Reject(e.Message)
            };
            window.ShowDialog();
        }
    }
}
