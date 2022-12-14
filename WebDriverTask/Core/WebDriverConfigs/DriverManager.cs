
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverTask.Core.BrowserConfigs;

namespace WebDriverTask.Core.WebDriverConfigs
{
    public class DriverManager: DriverBuilder
    {
        private static IWebDriver? driver = null;

        public DriverManager() : base() { }

        public IWebDriver Instance()
        {
            driver = Driver.GetDriver();
            return driver;
        }

        public DriverManager BuildDriver(BrowserType browser)
        {
            if(driver == null)
            {
                Build(browser);
                driver = Driver.GetDriver();
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
                driver.Manage().Window.Maximize();
            }
            return this;
        }

        public void AddArgumentsToDriver(params string[] arguments)
        {
            AddArguments(arguments);
        }

        public static void QuitDriver()
        {
            driver!.Quit();
            driver.Dispose();
            driver = null;
        }
        public static void CloseDriver()
        {
            Driver.Close();
        }

        public static void ClearAllCookies()
        {
            if (driver != null)
                driver!.Manage().Cookies.DeleteAllCookies();
        }

        public static void WaitPageToLoad(int secondsToWait = 5)
        {
            if (secondsToWait > 0 && driver != null)
                driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secondsToWait);
        }

        public static void WaitUntilElementDisplayed(IWebElement element, int waitTimeInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            wait.Until(c => element.Displayed);
        }

        public static void WaintUntilUrlChanged(string previousUrl, int waitTimeInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            wait.Until(c => c.Url != previousUrl);
        }

        public static bool WaitUntilElementIsInteractable(IWebElement element, int waitTimeInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            return wait.Until(c => element.Displayed && element.Enabled);
        }
    }
}
