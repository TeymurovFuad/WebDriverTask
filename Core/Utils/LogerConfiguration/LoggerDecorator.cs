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
