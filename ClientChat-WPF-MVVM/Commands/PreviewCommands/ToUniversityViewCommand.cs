using ClientChat_WPF_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.PreviewCommands
{
    public class ToUniversityViewCommand : CommandBase
    {
        private readonly RegistationUniverstityViewModel _registationUniverstityViewModel;
        private readonly NavigationPreviewViewModel _navigationPreviewViewModel;

        public ToUniversityViewCommand(RegistationUniverstityViewModel registationUniverstityViewModel, NavigationPreviewViewModel navigationPreviewViewModel )
        {
            _registationUniverstityViewModel = registationUniverstityViewModel;
            _navigationPreviewViewModel = navigationPreviewViewModel;
        }
        public override void Execute(object parameter)
        {
            _navigationPreviewViewModel.SelectedViewModel = _registationUniverstityViewModel;
        }

    }
}
