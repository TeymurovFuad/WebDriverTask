using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using WebDriverTask.Core.Browser.Configuration;

namespace WebDriverTask.Core.Browser
{
    public sealed class Chrome : IBrowser
    {
        private static IBrowser? _instance { get; set; } = null;
        public static IBrowser GetInstance => _instance ??= new Chrome();
        private IWebDriver? driver { get; set; }
        private RemoteWebDriver _remoteWebDriver { get; set; }
        private ChromeOptions _chromeOptions { get; set; }

        private Chrome()
        {
            _chromeOptions = new ChromeOptions();
        }

        public IWebDriver GetDriver()
        {
            driver = new ChromeDriver(_chromeOptions);
            return driver;
        }

        public IWebDriver GetRemoteDriver()
        {
            if (driver == null && driver?.GetType() == typeof(RemoteWebDriver))
                _remoteWebDriver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), _chromeOptions.ToCapabilities());
            return _remoteWebDriver;
        }

        public IBrowser SetOptions(DriverOptions? options)
        {
            if (options != null)
            {
                _chromeOptions = (ChromeOptions)options;
            }
            return this;
        }
    }
}
