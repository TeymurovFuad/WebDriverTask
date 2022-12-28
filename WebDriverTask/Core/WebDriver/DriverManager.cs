
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics.CodeAnalysis;
using WebDriverTask.Core.Browser;
using WebDriverTask.Core.Browser.Configuration;

namespace WebDriverTask.Core.WebDriver
{
    public class DriverManager : BrowserBuilder
    {
        private BrowserSetting _browserSetting { get; set; }

        public DriverManager() : base() { }

        public IWebDriver GetDriverInstance()
        {
            return GetDriver();
        }

        public void BuildDriver(BrowserType browserType)
        {
            Build(browserType);
            GetDriver();
            GetDriver()?.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
            GetDriver()?.Manage().Window.Maximize();
        }

        public void AddArgumentsToBrowser([DisallowNull] params string[] arguments)
        {
            _browserSetting?.AddArguments(arguments);
        }

        public void QuitDriver()
        {
            GetDriver()?.Quit();
            GetDriver()?.Dispose();
        }

        public void CloseDriver()
        {
            Close();
        }

        public void ClearAllCookies()
        {
            if (GetDriver() != null)
                GetDriver()!.Manage().Cookies.DeleteAllCookies();
        }
    }
}
