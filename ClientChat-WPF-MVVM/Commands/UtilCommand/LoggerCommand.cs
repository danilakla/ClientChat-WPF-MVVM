using ClientChat_WPF_MVVM.Services.LoggerService;
using ClientChat_WPF_MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientChat_WPF_MVVM.Commands.UtilCommand
{
    class LoggerCommand : CommandBase

    {
        private readonly Logger _logger;
        private readonly ChatView _chatView;
        private readonly ChatViewModel _chatViewModel;

        public LoggerCommand(Logger logger, ChatView chatView, ChatViewModel chatViewModel)
        {
            _logger = logger;
            _chatView = chatView;
            _chatViewModel = chatViewModel;
        }
        public override void Execute(object parameter)
        {
            Uri uri;
            if (_chatViewModel.IsSetStyle)
            {
                uri = new Uri(@"..\..\View\StyleTheme\LightStyle.xaml", UriKind.Relative);

            }
            else
            {
                uri = new Uri(@"..\..\View\StyleTheme\DarkStyle.xaml", UriKind.Relative);

            }
            _chatViewModel.IsSetStyle = !_chatViewModel.IsSetStyle;
            ResourceDictionary resourceDictionary=Application.LoadComponent(uri)as ResourceDictionary;
            _chatView.Resources.Clear();
            _chatView.Resources.MergedDictionaries.Add(resourceDictionary);
            _logger.LoggingInfoClick();
            
        }
    }
}
