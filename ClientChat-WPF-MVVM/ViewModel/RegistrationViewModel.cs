using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API.Authentication;
using ClientChat_WPF_MVVM.Services.TokentServices;
using ClientChat_WPF_MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel;
public class RegistrationViewModel:ViewModelBase
{
    private string _email;
    private string _password;


    public string Email
    {
        get { return _email; }
        set
        {
            _email = value;
            OnPropertyChanged("Email");
        }
    }
    public string Password
    {
        get { return _password; }
        set
        {
            _password = value;
            OnPropertyChanged("Password");
        }
    }
    public ICommand NavigateToLoginCommand { get; }

    public ICommand RegistrationUserAccountCommand { get; }

    public RegistrationViewModel(NavigationService<LoginViewModel> navigateSerivceRegViewModel, 
        NavigationWindowService<ChatView> navigationWindowCommand, 
        NavigationService<ChatViewModel> navigateSerivceChatViewModel, 
        AuthUserService<UserAuthInfoModel> authUserService,
        TokenServieces tokenSerivece, 
        UserStoreServices userStoreServices)
    {
        NavigateToLoginCommand = new NavigateCommand<LoginViewModel>(navigateSerivceRegViewModel);
        RegistrationUserAccountCommand = new RegistrationUserAccountCommand<ChatView,ChatViewModel>(navigationWindowCommand, navigateSerivceChatViewModel, authUserService, this,tokenSerivece, userStoreServices);

    }

    public ICommand LoginUserCommand { get; }


  
}
