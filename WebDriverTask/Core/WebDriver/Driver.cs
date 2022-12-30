using OpenQA.Selenium;
using WebDriverTask.Core.Browser;
using WebDriverTask.Core.Browser.Configuration;
using WebDriverTask.Core.CustomExceptions;

namespace WebDriverTask.Core.WebDriver
{
    public abstract class Driver: BrowserBuilder
    {
        private IWebDriver webDriver { get; set; }

        protected Driver() { }

        public IWebDriver GetDriver()
        {
            if (!isBuilt())
            {
                throw new DriverException("Webdriver is not set yet");
            }
            return webDriver;
        }

        protected void SetUpDriver(BrowserType browserType)
        {
            if(webDriver==null)
                webDriver = CreateBrowser(browserType);
        }

        public bool isBuilt()
        {
            return webDriver != null;
        }
    }
}
