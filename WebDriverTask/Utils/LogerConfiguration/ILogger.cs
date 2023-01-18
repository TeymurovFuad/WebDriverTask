namespace WebDriverTask.Utils.LogerConfiguration
{
    public interface ILogger
    {
        string CurrentDirectory { get; }
        string LogFileName { get; }
        string LogFolderPath { get; }
        string LogFilePath { get; }
        void Log(string message) { throw new NotImplementedException(); }
    }
}
