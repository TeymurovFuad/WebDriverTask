using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils.LogerConfiguration
{
    public abstract class LoggerDecorator : Logger, ILoggerDecorator
    {
        protected LoggerDecorator() { }

        public abstract void LogMessage(string message);
        public abstract void LogMessage(Exception exception);
        public abstract void LogMessage(Action action);
    }
}
