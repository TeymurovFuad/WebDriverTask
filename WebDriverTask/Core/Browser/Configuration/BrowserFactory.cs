using OpenQA.Selenium;
using WebDriverTask.Utils.Exceptions;

namespace WebDriverTask.Core.Browser.Configuration
{
    public abstract class BrowserFactory
    {
        private BrowserType _browserType { get; set; }
        Chrome chrome;
        Firefox firefox;

        protected BrowserFactory() : base()
        {
            chrome = new Chrome();
            firefox = new Firefox();
        }

        protected IWebDriver CreateBrowser(BrowserType browserType, DriverOptions? options=null)
        {
            IWebDriver driver;
            _browserType = browserType;
            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = chrome.GetDriver();
                    break;
                case BrowserType.Firefox:
                    driver = firefox.GetDriver();
                    break;
                case BrowserType.RemoteChrome:
                    driver = chrome.SetOptions(options).ConfigureRemoteDriver().GetDriver();
                    break;
                case BrowserType.RemoteFirefox:
                    driver = firefox.SetOptions(options).ConfigureRemoteDriver().GetDriver();
                    break;
                default:
                    throw new BrowserTypeException($"Wrong browser was passed: {browserType.ToString()}");
            }
            return driver;
        }
    }
}
