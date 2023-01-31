namespace Core.Utils.LogerConfiguration
{
    public abstract class BaseLogger : ILogger
    {
        public abstract string CurrentDirectory { get; protected set; }
        public abstract string LogFileName { get; protected set; }
        public abstract string LogFolderPath { get; protected set; }
        public abstract string LogFilePath { get; protected set; }

        public abstract Task Log(string message);
    }
}
