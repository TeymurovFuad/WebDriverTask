using System.Diagnostics;

namespace WebDriverTask.Utils.LogerConfiguration
{
    public sealed class InfoLogger: Logger
    {
        private static InfoLogger _instance { get; set; } = null;

        private InfoLogger(): base(fileName: "InfoLogger.txt") { }

        public static InfoLogger Instance()
        {
            if (_instance == null)
            {
                _instance = new InfoLogger();
            }
            return _instance;
        }

        public void LogInfo(Action action)
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
