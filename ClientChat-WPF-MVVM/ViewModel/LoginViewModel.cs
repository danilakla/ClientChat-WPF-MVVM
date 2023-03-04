using ClientChat_WPF_MVVM.Model;
using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.Services.API.Authentication;
using ClientChat_WPF_MVVM.Services.TokentServices;
using ClientChat_WPF_MVVM.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel;
public class LoginViewModel : ViewModelBase, INotifyDataErrorInfo
{
    private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();
    public bool HasErrors => _propertyErrors.Any();

    private string _email;
    private string _password;

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public string Email
    {
        get { return _email; }
        set
        {
            _email = value;
            //if (_password.Length < 4)
            //{
            //    AddError(nameof(Email), "more bykav for email");
            //}
            OnPropertyChanged("Email");
        }
    }
    public string Password
    {
        get { return _password; }
        set
        {
            _password = value;
            //if(_password.Length<4)
            //{
            //    AddError(nameof(Password), "more bykav for password");
            //}
            OnPropertyChanged("Password");
        }
    }
    public ICommand NavigateToRegistrationCommand { get; }
    public ICommand LoginUserAccountCommand { get; }


    public LoginViewModel(NavigationService<RegistrationViewModel> navigateSerivceLonginViewModel, 
        NavigationWindowService<ChatView> navigationWindowCommand, 
        NavigationService<ChatViewModel> navigateSerivceChatViewModel,
         AuthUserService<UserAuthInfoModel> authUserService,
        TokenServieces tokenSerivece,
        UserStoreServices userStoreServices)
    {
        NavigateToRegistrationCommand = new NavigateCommand<RegistrationViewModel>(navigateSerivceLonginViewModel);
        LoginUserAccountCommand = new LoginUserAccountCommand<ChatView, ChatViewModel>(navigationWindowCommand, navigateSerivceChatViewModel, authUserService,this, tokenSerivece, userStoreServices);
    }

    public IEnumerable GetErrors(string? propertyName)
    {
        return _propertyErrors.GetValueOrDefault(propertyName, null);
    }
    public void AddError(string properyName, string errorMessage)
    {
        if (!_propertyErrors.ContainsKey(properyName))
        {
            _propertyErrors.Add(properyName, new List<string>());
        }
        _propertyErrors[properyName].Add(errorMessage);
        OnErrorsChanged(properyName);
    }

    private void OnErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}

