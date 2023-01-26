using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Core.Browser.Factory;

namespace Core.Browser
{
    public sealed class Firefox : IBrowser
    {
        private static IBrowser? _instance { get; set; } = null;
        public static IBrowser GetInstance => _instance ??= new Firefox();
        IWebDriver? _driver { get; set; }
        RemoteWebDriver _remoteWebDriver { get; set; }
        FirefoxOptions _firefoxOptions { get; set; }

        private Firefox()
        {
            _firefoxOptions = new FirefoxOptions();
        }

        public IWebDriver GetDriver()
        {
            _driver?.Dispose();
            _driver = new FirefoxDriver(_firefoxOptions);
            return _driver;
        }

        public IWebDriver GetRemoteDriver()
        {
            if (_driver == null && _driver?.GetType() == typeof(RemoteWebDriver))
                _remoteWebDriver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), _firefoxOptions.ToCapabilities());
            return _remoteWebDriver;
        }

        public IBrowser SetOptions(DriverOptions? options)
        {
            if (options != null)
            {
                _firefoxOptions = (FirefoxOptions)options;
            }
            _firefoxOptions.AddArgument("-private");
            return this;
        }
    }
}
