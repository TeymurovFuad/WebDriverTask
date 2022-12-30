using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebDriverTask.Core.Extensions
{
    public static class DriverInteractions
    {
        public static void WaitPageToLoad(this IWebDriver driver, int secondsToWait = 5)
        {
            if (secondsToWait > 0 && driver != null)
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secondsToWait);
        }

        public static bool WaitUntilElementDisplayed(this IWebDriver driver, IWebElement element, int waitTimeInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            return wait.Until(c => element.Displayed);
        }

        public static bool WaintUntilUrlChanged(this IWebDriver driver, string previousUrl, int waitTimeInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            return wait.Until(c => c.Url != previousUrl);
        }

        public static bool WaitUntilElementIsInteractable(this IWebDriver driver, IWebElement element, int waitTimeInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            return wait.Until(c => element.Displayed && element.Enabled);
        }

        public static string GetUrl(this IWebDriver driver)
        {
            return driver.Url;
        }

        public static void SwitchToFrame(this IWebDriver driver, IWebElement frame)
        {
            driver.SwitchTo().Frame(frame);
        }

        public static void SwitchToMain(this IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }

        public static void GoToUrl(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
