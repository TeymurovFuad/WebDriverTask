using OpenQA.Selenium;
using WebDriverTask.Utils.Exceptions;

namespace WebDriverTask.Core.Browser.Configuration
{
    public abstract class BrowserFactory
    {
        protected BrowserType browserType { get; private set; }
        protected IBrowser browser { get; private set; }
        Chrome _chrome { get; }
        Firefox _firefox { get; }
        IWebDriver driver { get; set; }

        protected BrowserFactory() { }

        protected BrowserFactory SetBrowser(BrowserType browserType, DriverOptions? options = null)
        {
            if (browser == null && browserType != this.browserType)
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        browser = _chrome.GetInstance.SetOptions(options);
                        break;
                    case BrowserType.Firefox:
                        browser = _firefox.GetInstance.SetOptions(options);
                        break;
                    default:
                        throw new BrowserTypeException($"Wrong browser was passed: {browserType.ToString()}", new NotImplementedException());
                }
            }
            this.browserType = browserType;
            return this;
        }

        internal IWebDriver GetDriverInstance()
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = browser.GetDriver();
                    break;
                case BrowserType.Firefox:
                    driver = browser.GetDriver();
                    break;
                case BrowserType.RemoteChrome:
                    driver = browser.GetRemoteDriver();
                    break;
                case BrowserType.RemoteFirefox:
                    driver = browser.GetRemoteDriver();
                    break;
                default:
                    throw new BrowserTypeException($"Wrong browser was passed: {browserType.ToString()}");
            }
            return driver;
        }
    }
}
