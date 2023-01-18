namespace WebDriverTask.Utils.LogerConfiguration
{
    public sealed class TestLogger : Logger
    {
        private static TestLogger _instance { get; set; }

        public TestLogger() : base(fileName: "TestLogger.txt") { }

        public static TestLogger Instance()
        {
            if (_instance == null)
            {
                _instance = new TestLogger();
            }
            return _instance;
        }

        public void OnTestEvent(string report)
        {
            Log(report);
        }

        public void LogTest(string message)
        {
            Log(message);
        }
    }
}
