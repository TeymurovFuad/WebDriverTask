using OpenQA.Selenium;
using WebDriverTask.Core.CustomExceptions;

namespace WebDriverTask.Core.WebDriver
{
    public abstract class Driver
    {
        private IWebDriver _webDriver;

        protected Driver() { }

        protected IWebDriver GetDriver()
        {
            if (!isBuilt())
            {
                throw new DriverException("Webdriver is not set yet");
            }
            return _webDriver;
        }

        public Driver Instance()
        {
            return this;
        }

        protected void SetDriver(IWebDriver driver)
        {
            if(_webDriver==null)
                _webDriver = driver;
        }

        public bool isBuilt()
        {
            return _webDriver != null;
        }
    }
}
