using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverTask.Core.BrowserConfigs;

namespace WebDriverTask.Core.WebDriverConfigs
{
    public abstract class DriverManager: DriverBuilder
    {
        private static IWebDriver? driver = null;

        protected DriverManager(BrowserType browserType): base(browserType) { }

        public DriverBuilder Instance()
        {
            try
            {
                Driver.GetDriver();
            }
            catch (NullReferenceException)
            {
                Build();
            }
            catch(ObjectDisposedException)
            {
                throw;
            }
            finally
            {
                driver = Driver.GetDriver();
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
                driver.Manage().Window.Maximize();
            }
            return this;
        }

        public static void QuitDriver()
        {
            driver!.Quit();
            driver.Dispose();
            driver = null;
        }
        public static void CloseDriver()
        {
            if (driver != null)
                driver!.Close();
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
