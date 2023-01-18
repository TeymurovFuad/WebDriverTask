namespace WebDriverTask.Utils.LogerConfiguration
{
    public sealed class ErrorLogger: Logger
    {
        private static ErrorLogger? _instance { get; set; } = null;

        private ErrorLogger() : base(fileName: "ErrorLog.txt") { }

        public static ErrorLogger Instance()
        {
            if (_instance == null)
            {
                _instance = new ErrorLogger();
            }
            return _instance;
        }

        public void LogError(Exception e)
        {
            Log(e.Message);
        }

        public void LogError(string message)
        {
            Log(message);
        }

        public void LogError(Action action)
        {
            try
            {
                action();
            }
            catch(Exception e)
            {
                Log(e.Message);
            }
        }
    }
}
