using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Model.AuthModels;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API.Authentication;
using ClientChat_WPF_MVVM.Services.TokentServices;
using ClientChat_WPF_MVVM.Strore;
using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;


public class LoginUserAccountCommand<TView, TViewModel> : CommandAsyncBase where TView : Window
                                                           where TViewModel : ViewModelBase
{
    private readonly NavigationWindowService<TView> _navigationWindowService;
    private readonly NavigationService<TViewModel> _navigationService;
    private readonly AuthUserService<ResponseAuthServerUserData> _authUserService;
    private readonly LoginViewModel _loginViewModel;
    private readonly TokenServieces _tokenServieces;
    private readonly UserStoreServices _userStoreServices;

    public LoginUserAccountCommand(NavigationWindowService<TView> navigationWindowService, 
                                           NavigationService<TViewModel> navigationService,
                                           AuthUserService<ResponseAuthServerUserData> authUserService,
                                           LoginViewModel loginViewModel,
                                           TokenServieces tokenServieces,
                                           UserStoreServices userStoreServices
                                           )
    {

        _navigationWindowService = navigationWindowService;
        _navigationService = navigationService;
        _authUserService = authUserService;
        _loginViewModel = loginViewModel;
        _tokenServieces = tokenServieces;
        _userStoreServices = userStoreServices;
    }

    public override async Task ExecuteAsync(object parameter)
    {

        try
        {
        var userDto = new UserAuthDto { Username = _loginViewModel.Email, Password = _loginViewModel.Password };
           var data= await _authUserService.LoginAccount(userDto);


            var tokens = new UserAuthInfoModel
            {
                AccToken = new AccessToken
                {
                    AccToken = data.token,
            },
            RefToken= new RefreshToken
            {
                RefToken=data.token,
            }

        };
        _tokenServieces.SetTokenAllToken(tokens.AccToken, tokens.RefToken);
        _userStoreServices.CreateProfileLocaly(userDto);
        _navigationService.Navigate();
        _navigationWindowService.Navigate();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
    }
}