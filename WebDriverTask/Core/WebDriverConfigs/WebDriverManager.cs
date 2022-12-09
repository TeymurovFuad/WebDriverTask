using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using WebDriverTask.Core.BrowserConfigs;

namespace WebDriverTask.Core.WebDriverConfigs
{
    public abstract class WebDriverManager
    {
        private static IWebDriver? driver = null;

        public static IWebDriver Instance(BrowserType browser)
        {
            if (driver == null)
            {
                driver = WebDriver.GetDriver();
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void QuitDriver()
        {
            driver!.Quit();
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

        public static void WaintUntilElementDisplayed(By locator, int waitTimeInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            wait.Until(c => c.FindElement(locator));
        }

        public static void WaintUntilUrlChanged(string previousUrl, int waitTimeInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            wait.Until(c => c.Url != previousUrl);
        }
    }
}
