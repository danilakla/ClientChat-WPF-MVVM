using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API.Authentication;
using ClientChat_WPF_MVVM.Services.TokentServices;
using ClientChat_WPF_MVVM.ViewModel;
using System.Threading.Tasks;
using System.Windows;


public class RegistrationUserAccountCommand<TView, TViewModel> : CommandAsyncBase where TView : Window
                                                           where TViewModel : ViewModelBase
{
    private readonly NavigationWindowService<TView> _navigationWindowService;
    private readonly NavigationService<TViewModel> _navigationService;
    private readonly AuthUserService<UserAuthInfoModel> _authUserService;
    private readonly RegistrationViewModel _registrationViewModel;
    private readonly TokenServieces _tokenServieces;
    private readonly UserStoreServices _userStoreServices;

    public RegistrationUserAccountCommand(NavigationWindowService<TView> navigationWindowService,
                                           NavigationService<TViewModel> navigationService,
                                           AuthUserService<UserAuthInfoModel> authUserService,
                                           RegistrationViewModel registrationViewModel,
                                           TokenServieces tokenServieces,
                                           UserStoreServices userStoreServices

                                           )
    {

        _navigationWindowService = navigationWindowService;
        _navigationService = navigationService;
        _authUserService = authUserService;
        _registrationViewModel = registrationViewModel;
        _tokenServieces = tokenServieces;
        _userStoreServices = userStoreServices;
    }

    public override async Task ExecuteAsync(object parameter)
    {

        try
        {
            var userDto = new UserAuthDto { Email = _registrationViewModel.Email, Password = _registrationViewModel.Password };

            var tokens = new UserAuthInfoModel
            {
                AccToken = new AccessToken
                {
                    AccToken = "SOME TEXTX"
                },
                RefToken = new RefreshToken
                {
                    RefToken = "REFS REXC"
                }

            };
            //await _authUserService.CreateAccount(userDto);
            _userStoreServices.CreateProfileLocaly( userDto );
            _tokenServieces.SetTokenAllToken(tokens.AccToken, tokens.RefToken);
            _navigationService.Navigate();
            _navigationWindowService.Navigate();
        }
        catch (System.Exception)
        {

            throw;
        }


    }
}