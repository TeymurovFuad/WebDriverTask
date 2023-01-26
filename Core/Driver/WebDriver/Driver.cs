using OpenQA.Selenium;
using Core.Browser;
using Core.Browser.Factory;
using Core.Utils.Exceptions;

namespace Core.WebDriver
{
    public class Driver : BrowserBuilder
    {
        private IWebDriver _webDriver { get; set; }

        protected Driver() { }

        public IWebDriver GetDriver()
        {
            if (!isBuilt())
            {
                throw new DriverException("Webdriver is not set yet");
            }
            return _webDriver;
        }

        protected void SetUpDriver(BrowserType browserType, DriverOptions driverOptions)
        {
            _webDriver = Build(browserType, driverOptions);
        }

        public bool isBuilt()
        {
            return _webDriver != null;
        }
    }
}
