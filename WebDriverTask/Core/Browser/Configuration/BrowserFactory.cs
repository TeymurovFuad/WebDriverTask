using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebDriverTask.Core.WebDriver;
using WebDriverTask.Utils.Exceptions;

namespace WebDriverTask.Core.Browser.Configuration
{
    public abstract class BrowserFactory
    {
        protected BrowserType browserType { get; private set; }
        protected IBrowser browser { get; private set; }
        IWebDriver driver { get; set; }

        protected BrowserFactory() { }

        protected BrowserFactory SetBrowser(BrowserType browserType, DriverOptions? options = null)
        {
            if (browser != null)
            {
                if (browserType != this.browserType)
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
                }
                this.browserType = browserType;
                return this;
            }
            throw new BrowserTypeException("Browser type not defined", new NullReferenceException());
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
