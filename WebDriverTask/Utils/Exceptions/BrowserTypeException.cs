﻿namespace WebDriverTask.Utils.Exceptions
{
    public class BrowserTypeException : Exception
    {
        public BrowserTypeException() : base()
        {
        }

        public BrowserTypeException(string message) : base(message)
        {
        }

        public BrowserTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
