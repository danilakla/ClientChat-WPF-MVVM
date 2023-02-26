using ClientChat_WPF_MVVM.Services;
using ClientChat_WPF_MVVM.View;
using ClientChat_WPF_MVVM.View.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.ChatCommand
{
    class OpenModalDialogCommand : CommandBase
    {
        private readonly NavigationWindowService<ChatView> _navigationWindowService;

        public OpenModalDialogCommand(NavigationWindowService<ChatView> navigationWindowService)
        {
            _navigationWindowService = navigationWindowService;
        }
        public override void Execute(object parameter)
        {
            (_navigationWindowService.GetCurrentWindow() as ChatView).MainGrid.Children.Add(new CustomModalDialog());
        }
    }
}
