
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics.CodeAnalysis;
using WebDriverTask.Core.Browser;
using WebDriverTask.Core.Browser.Configuration;

namespace WebDriverTask.Core.WebDriver
{
    public class DriverManager : BrowserBuilder
    {
        IWebDriver webDriver { get; set; }
        private BrowserSetting _browserSetting { get; set; }

        public DriverManager() : base() { }

        public IWebDriver GetDriverInstance()
        {
            return GetDriver();
        }

        public DriverManager BuildDriver(BrowserType browserType)
        {
            Build(browserType);
            webDriver = GetDriver();
            webDriver?.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
            webDriver?.Manage().Window.Maximize();
            return this;
        }

        public void AddArgumentsToBrowser([DisallowNull] params string[] arguments)
        {
            _browserSetting?.AddArguments(arguments);
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

        public void ClearAllCookies()
        {
            if (webDriver != null)
                webDriver!.Manage().Cookies.DeleteAllCookies();
        }
    }
}
