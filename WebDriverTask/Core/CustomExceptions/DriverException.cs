namespace WebDriverTask.Core.CustomExceptions
{
    public class DriverException: Exception
    {
        public DriverException()
        {
        }

        public DriverException(string message)
            : base(message)
        {
        }

        public DriverException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
