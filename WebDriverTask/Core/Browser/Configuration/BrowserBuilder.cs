using OpenQA.Selenium;

namespace WebDriverTask.Core.Browser.Configuration
{
    public abstract class BrowserBuilder : BrowserFactory
    {
        private IWebDriver _webDriver;

        protected BrowserBuilder() { }

        protected IWebDriver Build(BrowserType browserType, DriverOptions driverOptions)
        {
            _webDriver = SetBrowser(browserType, driverOptions).GetDriverInstance();
            return _webDriver;
        }
    }
}
