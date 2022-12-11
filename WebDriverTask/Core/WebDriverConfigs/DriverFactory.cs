using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core.BrowserConfigs;
using WebDriverTask.Core.CustomExceptions;

namespace WebDriverTask.Core.WebDriverConfigs
{
    public abstract class DriverFactory
    {
        private static BrowserType _browserType { get; set; }

        public static BrowserType GetBrowserType()
        {
            try
            {
                return _browserType;
            }
            catch (Exception)
            {
                throw new BrowserTypeException("Browser type is not set. It is expected to be set when create driver");
            }
        }

        protected static void CreateDriver(BrowserType browserType)
        {
            IWebDriver? driver = null;
            _browserType = browserType;
            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new BrowserTypeException($"Wrong browser was passed: {browserType.ToString()}");
            }
            Driver.SetDriver(driver);
        }
    }
}
