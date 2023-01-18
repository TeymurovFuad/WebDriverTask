using WebDriverTask.Utils.LogerConfiguration;

namespace WebDriverTask.Utils.Helpers
{
    public class LoggerHelper
    {
        private LoggerHelper() { }

        public static void Error(string message)
        {
            ErrorLogger.Instance().LogError(message);
        }

        public static void Info(Action action)
        {
            InfoLogger.Instance().LogInfo(() => action());
        }
    }
}
