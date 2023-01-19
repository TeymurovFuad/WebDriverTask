using OpenQA.Selenium;
using WebDriverTask.Core.Browser;
using WebDriverTask.Core.Browser.Factory;
using WebDriverTask.Utils.Exceptions;

namespace WebDriverTask.Core.WebDriver
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
