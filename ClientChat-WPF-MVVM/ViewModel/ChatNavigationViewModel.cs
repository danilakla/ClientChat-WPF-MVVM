using ClientChat_WPF_MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientChat_WPF_MVVM.ViewModel
{
   public class ChatNavigationViewModel:ViewModelBase
    {

        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get => _selectedViewModel;
            set { _selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        public ChatNavigationViewModel(WelcomeChatViewModel welcomeChatViewModel, ProfileViewModel profileViewModel)
        {
            SelectedViewModel = welcomeChatViewModel;
            ToProfileView = new ToProfileViewCommand(profileViewModel, this);
            ToWelcomeViewCommand = new ToWelcomeViewCommand(welcomeChatViewModel, this);

        }
        public ICommand ToProfileView { get; }
        public ICommand ToWelcomeViewCommand { get; }

        
    }
}
