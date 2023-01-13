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
        IWebDriver driver;
        Chrome _chrome;
        Firefox _firefox;

        protected BrowserFactory() { }

        private void SetBrowser(BrowserType browserType)
        {
            if (browser == null && browserType != this.browserType)
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        browser = _chrome.GetInstance;
                        break;
                    case BrowserType.Firefox:
                        browser = _firefox.GetInstance;
                        break;
                    default:
                        throw new BrowserTypeException($"Wrong browser was passed: {browserType.ToString()}", new NotImplementedException());
                }
            }
        }

        protected IWebDriver GetDriverInstance(BrowserType browserType, DriverOptions? options=null)
        {
            SetBrowser(browserType);
            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = browser.GetDriver();
                    break;
                case BrowserType.Firefox:
                    driver = browser.GetDriver();
                    break;
                case BrowserType.RemoteChrome:
                    driver = browser.SetOptions(options).GetRemoteDriver();
                    break;
                case BrowserType.RemoteFirefox:
                    driver = browser.SetOptions(options).GetRemoteDriver();
                    break;
                default:
                    throw new BrowserTypeException($"Wrong browser was passed: {browserType.ToString()}");
            }
            return driver;
        }
    }
}
