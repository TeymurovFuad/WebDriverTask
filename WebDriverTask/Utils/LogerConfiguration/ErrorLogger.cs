namespace WebDriverTask.Utils.LogerConfiguration
{
    public class ErrorLogger: Logger
    {
        public ErrorLogger() { }

        public void LogError(string message)
        {
            Log(message);
        }
    }
}
