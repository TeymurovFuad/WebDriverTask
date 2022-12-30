using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core.CustomExceptions;

namespace WebDriverTask.Core.Browser.Configuration
{
    public abstract class BrowserFactory
    {
        private BrowserType _browserType { get; set; }

        protected BrowserFactory() : base() { }

        protected IWebDriver CreateBrowser(BrowserType browserType)
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
            return driver;
        }
    }
}
