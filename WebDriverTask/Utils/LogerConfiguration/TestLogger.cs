namespace WebDriverTask.Utils.LogerConfiguration
{
    public class TestLogger : Logger
    {
        public TestLogger()
        {
            LogFileName = "TestLogger.txt";
        }

        public void OnTestEvent(string report)
        {
            Log(report);
        }
    }
}
