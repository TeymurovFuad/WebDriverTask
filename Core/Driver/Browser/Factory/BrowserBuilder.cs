using OpenQA.Selenium;

namespace Core.Browser.Factory
{
    public abstract class BrowserBuilder : BrowserFactory
    {
        private IWebDriver _webDriver;

        protected BrowserBuilder() { }

        protected IWebDriver Build(BrowserType browserType, DriverOptions driverOptions)
        {
            return SetBrowser(browserType, driverOptions).GetDriverInstance();
        }
    }
}
