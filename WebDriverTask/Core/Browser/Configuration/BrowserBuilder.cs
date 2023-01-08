using OpenQA.Selenium;

namespace WebDriverTask.Core.Browser.Configuration
{
    public abstract class BrowserBuilder : BrowserFactory
    {
        protected BrowserBuilder() { }

        protected void Build(BrowserType browserType, DriverOptions driverOptions)
        {
            CreateBrowser(browserType, driverOptions);
        }
    }
}
