using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using WebDriverTask.Core.Browser.Configuration;

namespace WebDriverTask.Core.Browser
{
    public sealed class Firefox : IBrowser
    {
        private IBrowser? _instance { get; set; } = null;
        public IBrowser GetInstance => _instance ??= new Firefox();
        private IWebDriver? driver { get; set; }
        private RemoteWebDriver _remoteWebDriver { get; set; }
        private FirefoxOptions _firefoxOptions { get; set; }

        private Firefox()
        {
            _firefoxOptions = new FirefoxOptions();
        }

        public IWebDriver GetDriver()
        {
            if (driver == null && driver?.GetType() == typeof(IWebDriver))
                driver = new FirefoxDriver(_firefoxOptions);
            return driver;
        }

        public IWebDriver GetRemoteDriver()
        {
            if (driver == null && driver?.GetType() == typeof(RemoteWebDriver))
                _remoteWebDriver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), _firefoxOptions.ToCapabilities());
            return _remoteWebDriver;
        }

        public IBrowser SetOptions(DriverOptions? options)
        {
            if (options != null)
            {
                _firefoxOptions = (FirefoxOptions)options;
            }
            return this;
        }
    }
}
