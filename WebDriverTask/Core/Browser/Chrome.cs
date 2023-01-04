using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core.Browser.Configuration;

namespace WebDriverTask.Core.Browser
{
    public sealed class Chrome: IBrowser
    {
        bool isRemote;

        private IWebDriver driver { get; set; }
        private RemoteWebDriver _remoteWebDriver;
        private ChromeOptions _chromeOptions;

        public Chrome()
        {
            _chromeOptions = new ChromeOptions();
        }

        public IWebDriver GetDriver()
        {
            if (!isRemote)
            {
                driver = new ChromeDriver();
                return driver;
            }
            return _remoteWebDriver;
        }

        public IBrowser ConfigureRemoteDriver()
        {
            _remoteWebDriver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), _chromeOptions.ToCapabilities());
            isRemote = true;
            return this;
        }

        public IBrowser SetOptions(ChromeOptions? options)
        {
            if (options != null)
            {
                _chromeOptions = options;
            }
            return this;
        }

        public IBrowser SetOptions(DriverOptions? options)
        {
            if (options != null)
            {
                _chromeOptions = options as ChromeOptions;
            }
            return this;
        }
    }
}
