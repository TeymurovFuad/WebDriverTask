using System.Diagnostics;

namespace WebDriverTask.Utils.LogerConfiguration
{
    public sealed class InfoLogger: LoggerDecorator
    {
        private static InfoLogger _instance = null;
        public static InfoLogger Instance { get { return GetInstance(); } }

        private InfoLogger() { }

        private static InfoLogger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new InfoLogger();
            }
            return _instance;
        }

        public override void LogMessage(string message)
        {
            Log($"[TEST] {message}");
        }

        public override void LogMessage(Exception exception)
        {
            Log($"[TEST] {exception.Message}");
        }

        public override void LogMessage(Action action)
        {
            var start = DateTime.Now;
            var stackTrace = new StackTrace();
            var stackFrame = stackTrace.GetFrame(1);
            var method = stackFrame?.GetMethod();
            Log($"Entering method {method?.Name} in class {method?.DeclaringType?.Name} in file {stackFrame?.GetFileName()}");
            action();
            var end = DateTime.Now;
            var duration = end - start;
            Log($"Exiting method {method?.Name}...{Environment.NewLine} Execution Time: {duration.TotalMilliseconds} ms");
        }
    }
}
