
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics.CodeAnalysis;
using WebDriverTask.Core.Browser;
using WebDriverTask.Core.Browser.Configuration;

namespace WebDriverTask.Core.WebDriver
{
    public class DriverManager : BrowserBuilder
    {
        private IWebDriver? _driver { get; set; }
        private BrowserSetting _browserSetting { get; set; }

        public DriverManager() : base() { }

        public void BuildDriver(BrowserType browserType)
        {
            Build(browserType);
            _driver = GetDriver();
            _driver?.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
            _driver?.Manage().Window.Maximize();
        }

        public void AddArgumentsToBrowser([DisallowNull] params string[] arguments)
        {
            _browserSetting?.AddArguments(arguments);
        }

        public void QuitDriver()
        {
            _driver?.Quit();
            _driver?.Dispose();
            _driver = null;
        }

        public void CloseDriver()
        {
            Close();
        }

        public void ClearAllCookies()
        {
            if (_driver != null)
                _driver!.Manage().Cookies.DeleteAllCookies();
        }

        public void WaitPageToLoad(int secondsToWait = 5)
        {
            if (secondsToWait > 0 && _driver != null)
                _driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secondsToWait);
        }

        public bool WaitUntilElementDisplayed(IWebElement element, int waitTimeInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            return wait.Until(c => element.Displayed);
        }

        public bool WaintUntilUrlChanged(string previousUrl, int waitTimeInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            return wait.Until(c => c.Url != previousUrl);
        }

        public bool WaitUntilElementIsInteractable(IWebElement element, int waitTimeInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            return wait.Until(c => element.Displayed && element.Enabled);
        }
    }
}
