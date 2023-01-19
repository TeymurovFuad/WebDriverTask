using OpenQA.Selenium;
using WebDriverTask.Utils.Exceptions;

namespace WebDriverTask.Core.Browser.Factory
{
    public abstract class BrowserFactory
    {
        protected BrowserType browserType { get; private set; }
        protected IBrowser browser { get; private set; }
        IWebDriver driver { get; set; }

        protected BrowserFactory() { }

        protected BrowserFactory SetBrowser(BrowserType browserType, DriverOptions? options = null)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    browser = Chrome.GetInstance.SetOptions(options);
                    break;
                case BrowserType.Firefox:
                    browser = Firefox.GetInstance.SetOptions(options);
                    break;
                default:
                    throw new BrowserTypeException($"There is no implementation for a given browser: {browserType.ToString()}", new NotImplementedException());
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
