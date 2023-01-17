using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Utils.LogerConfiguration;

namespace WebDriverTask.Utils.Helpers
{
    public class LoggerHelper
    {
        private static ErrorLogger _errorLogger;

        private LoggerHelper()
        {
            _errorLogger = new ErrorLogger();
        }

        public static void Loging(string message)
        {
            _errorLogger.Log(message);
        }
    }
}
