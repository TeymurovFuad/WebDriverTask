using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace WebDriverTask.Utils.LogerConfiguration
{
    public sealed class ErrorLogger: LoggerDecorator
    {
        private static ErrorLogger _instance = null;
        public static ErrorLogger Instance { get { return GetInstance(); } }

        private ErrorLogger() { }

        private static ErrorLogger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ErrorLogger();
            }
            return _instance;
        }

        public override void LogMessage(string message)
        {
            Log($"[ERROR] {message}");
        }

        public override void LogMessage(Exception exception)
        {
            Log($"[ERROR] {exception.Message}");
        }

        public override void LogMessage(Action action)
        {
            try
            {
                action();
            }
            catch(Exception e)
            {
                Log($"[ERROR] {e.Message}");
            }
        }
    }
}
