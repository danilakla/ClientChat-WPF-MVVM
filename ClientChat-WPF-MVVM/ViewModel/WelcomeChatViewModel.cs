using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.ViewModel
{
 public   class WelcomeChatViewModel: ViewModelBase
    {
        private object _selectedViewModel;
        public object ChatBarView
        {
            get => _selectedViewModel;
            set { _selectedViewModel = value; OnPropertyChanged("ChatBarView"); }
        }
        
        public WelcomeChatViewModel(ChatBarViewModel chatBarViewModel)
        {
            ChatBarView = chatBarViewModel;
        }
    }
}
