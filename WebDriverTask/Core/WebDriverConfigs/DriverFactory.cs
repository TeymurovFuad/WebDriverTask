using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core.BrowserConfigs;

namespace WebDriverTask.Core.WebDriverConfigs
{
    public abstract class DriverFactory
    {
        public static BrowserType _browserType { get; set; }
        protected DriverFactory(BrowserType browserType)
        {
            _browserType = browserType;
        }

        public static void CreateDriver()
        {
            IWebDriver? driver = null;
            switch (_browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException($"Wrong browser was passed: {nameof(_browserType)}");
            }
            Driver.SetWebDriver(driver);
        }
    }
}
