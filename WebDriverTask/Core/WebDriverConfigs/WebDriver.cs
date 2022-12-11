using OpenQA.Selenium;

namespace WebDriverTask.Core.WebDriverConfigs
{
    public static class Driver
    {
        private static IWebDriver? _webDriver = null;

        public static IWebDriver GetDriver()
        {
            if (_webDriver == null)
            {
                throw new NullReferenceException($"Webdriver is not set");
            }
            return _webDriver;
        }

        public static void SetWebDriver(IWebDriver driver)
        {
            _webDriver = driver;
        }
    }
}
