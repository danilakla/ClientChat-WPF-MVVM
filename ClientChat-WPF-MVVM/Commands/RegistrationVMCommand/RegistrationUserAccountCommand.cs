using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Model.AuthModels;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API.Authentication;
using ClientChat_WPF_MVVM.Services.API.ProfileServices;
using ClientChat_WPF_MVVM.Services.TokentServices;
using ClientChat_WPF_MVVM.ViewModel;
using System.Threading.Tasks;
using System.Windows;


public class RegistrationUserAccountCommand<TView, TViewModel> : CommandAsyncBase where TView : Window
                                                           where TViewModel : ViewModelBase
{
    private readonly ProfileSeriveces<ProfileDto> _profileSeriveces;
    private readonly NavigationWindowService<TView> _navigationWindowService;
    private readonly NavigationService<TViewModel> _navigationService;
    private readonly AuthUserService<ResponseAuthServerUserData> _authUserService;
    private readonly RegistrationViewModel _registrationViewModel;
    private readonly TokenServieces _tokenServieces;
    private readonly UserStoreServices _userStoreServices;

    public RegistrationUserAccountCommand(ProfileSeriveces<ProfileDto> profileSeriveces, NavigationWindowService<TView> navigationWindowService,
                                           NavigationService<TViewModel> navigationService,
                                           AuthUserService<ResponseAuthServerUserData> authUserService,
                                           RegistrationViewModel registrationViewModel,
                                           TokenServieces tokenServieces,
                                           UserStoreServices userStoreServices

                                           )
    {
        _profileSeriveces = profileSeriveces;
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
            var userDto = new UserAuthDto { Username = _registrationViewModel.Email, Password = _registrationViewModel?.Password?.ToString() };

            var data=await _authUserService.CreateAccount(userDto);

            var tokens = new UserAuthInfoModel
            {
                AccToken = new AccessToken
                {
                    AccToken = data.token
                },
                RefToken = new RefreshToken
                {
                        RefToken = data.token
                }

            };
            _userStoreServices.CreateProfileLocaly( new UserAuthDto { Username=data.user} );
            _tokenServieces.SetTokenAllToken(tokens.AccToken, tokens.RefToken);
            _profileSeriveces.CreateProfile(new ProfileDto { Name = userDto.Username});
            _navigationService.Navigate();
            _navigationWindowService.Navigate();
        }
        catch (System.Exception)
        {

            throw;
        }


    }
}