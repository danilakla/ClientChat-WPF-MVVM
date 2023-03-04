using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat_WPF_MVVM.Services.LoggerService
{
    public class Logger
    {
        private int countClick = 0;
        public void LoggingInfoClick()
        {

            using(var stream = new StreamWriter("logger.txt",true))
            {
                stream.WriteLine($"click is happend [{DateTime.Now}] : coutn click {countClick}");
            countClick++;
            }
        }

        public void EventLogger(string text)
        {

            using (var stream = new StreamWriter("loggerEvent.txt", true))
            {
                stream.WriteLine(text);
                countClick++;
            }
        }
    }
}
