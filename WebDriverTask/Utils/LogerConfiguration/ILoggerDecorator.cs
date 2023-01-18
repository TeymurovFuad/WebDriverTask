using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask.Utils.LogerConfiguration
{
    public interface ILoggerDecorator: ILogger
    {
        void LogMessage(string message);
        void LogMessage(Exception exception);
        void LogMessage(Action action);
    }
}
