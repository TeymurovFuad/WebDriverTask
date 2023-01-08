using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core.Browser.Configuration;

namespace WebDriverTask.Core.Browser
{
    public sealed class Firefox: IBrowser
    {
        bool isRemote;

        private IWebDriver driver;
        private RemoteWebDriver _remoteWebDriver;
        private FirefoxOptions _firefoxOptions;
        public Firefox()
        {
            _firefoxOptions = new FirefoxOptions();
        }

        public IWebDriver GetDriver()
        {
            if (!isRemote)
            {
                driver = new FirefoxDriver();
                return driver;
            }
            return _remoteWebDriver;
        }

        public IBrowser ConfigureRemoteDriver()
        {
            _remoteWebDriver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), _firefoxOptions.ToCapabilities());
            isRemote = true;
            return this;
        }

        public IBrowser SetOptions(FirefoxOptions? options)
        {
            if (options != null)
            {
                _firefoxOptions = options;
            }
            return this;
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
