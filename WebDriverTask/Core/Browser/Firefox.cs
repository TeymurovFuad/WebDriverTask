using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace WebDriverTask.Core.Browser
{
    public sealed class Firefox
    {
        private IWebDriver driver;
        private FirefoxOptions _firefoxOptions;
        public Firefox()
        {
            driver = new FirefoxDriver();
            _firefoxOptions = new FirefoxOptions();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public Firefox ConfigureRemoteDriver()
        {
            driver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), _firefoxOptions.ToCapabilities());
            return this;
        }

        public Firefox SetOptions(FirefoxOptions? options)
        {
            if (options != null)
            {
                _firefoxOptions = options;
            }
            return this;
        }

        public Firefox SetOptions(DriverOptions? options)
        {
            if (options != null)
            {
                _firefoxOptions = (FirefoxOptions)options;
            }
            return this;
        }
    }
}
