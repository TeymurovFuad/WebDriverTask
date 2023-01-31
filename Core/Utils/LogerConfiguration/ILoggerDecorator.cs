namespace Core.Utils.LogerConfiguration
{
    public interface ILoggerDecorator: ILogger
    {
        void LogMessage(string message);
        void LogMessage(Exception exception);
        void LogMessage(Action action);
    }
}
