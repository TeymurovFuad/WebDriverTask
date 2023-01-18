namespace WebDriverTask.Utils.LogerConfiguration
{
    public sealed class TestLogger : LoggerDecorator
    {
        private static TestLogger _instance = null;
        public static TestLogger Instance { get { return GetInstance(); } }

        public TestLogger() { }

        private static TestLogger GetInstance()
        {
            if(_instance == null)
            {
                _instance = new TestLogger();
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
            try
            {
                action();
            }
            catch (Exception e)
            {
                Log($"[TEST] {e.Message}");
            }
        }
    }
}
