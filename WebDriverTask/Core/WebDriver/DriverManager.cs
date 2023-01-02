
using OpenQA.Selenium;
using WebDriverTask.Core.Browser;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Core.WebDriver
{
    public class DriverManager : Driver
    {
        IWebDriver webDriver { get; set; }
        public DriverManager() { }

        public IWebDriver GetWebDriver()
        {
            return webDriver;
        }

        private void SetWebDriver()
        {
            webDriver = GetDriver();
        }

        public void BuildDriver(BrowserType browserType, DriverOptions driverOptions)
        {
            SetUpDriver(browserType, driverOptions);
            SetWebDriver();
            webDriver?.WaitPageToLoad();
            webDriver?.MaximizeBrowser();
        }

        public void QuitDriver()
        {
            webDriver?.Quit();
            webDriver?.Dispose();
        }

        public void CloseDriver()
        {
            webDriver?.Close();
        }
    }
}
