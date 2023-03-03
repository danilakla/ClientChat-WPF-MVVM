using ClientChat_WPF_MVVM.Services.LoggerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Commands.UtilCommand
{
    class LoggerCommand : CommandBase

    {
        private readonly Logger _logger;

        public LoggerCommand(Logger logger)
        {
            _logger = logger;
        }
        public override void Execute(object parameter)
        {
            _logger.LoggingInfoClick();
        }
    }
}
