using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core.CustomExceptions;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Core.Browser.Configuration
{
    public abstract class BrowserFactory : Driver
    {
        protected BrowserFactory() : base() { }

        private BrowserType _browserType { get; set; }

        public BrowserType GetBrowserType()
        {
            try
            {
                return _browserType;
            }
            catch (Exception)
            {
                throw new BrowserTypeException("Browser type is not set yet. It is expected to be set when creating webDriver");
            }
        }

        protected void CreateBrowser(BrowserType browserType)
        {
            IWebDriver driver;
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
            SetDriver(driver);
        }
    }
}
