using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace WebDriverTask.Core.Browser
{
    public sealed class Chrome
    {
        bool isRemote;

        private IWebDriver driver;
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
            }
            return driver;
        }

        public Chrome ConfigureRemoteDriver()
        {
            driver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), _chromeOptions.ToCapabilities());
            isRemote = true;
            return this;
        }

        public Chrome SetOptions(ChromeOptions? options)
        {
            if (options != null)
            {
                _chromeOptions = options;
            }
            return this;
        }

        public Chrome SetOptions(DriverOptions? options)
        {
            if (options != null)
            {
                _chromeOptions = (ChromeOptions)options;
            }
            return this;
        }
    }
}
