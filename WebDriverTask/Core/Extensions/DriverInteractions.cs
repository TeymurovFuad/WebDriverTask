using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebDriverTask.Core.Extensions
{
    public static class DriverInteractions
    {
        public static void WaitPageToLoad(this IWebDriver driver, int secondsToWait=5, Action? exceptedAction=null)
        {
            if (secondsToWait > 0 && driver != null)
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secondsToWait);
        }

        private static WebDriverWait Wait(IWebDriver driver, int waitTimeInSeconds=5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            return wait;
        }

        public static bool WaitUntilElementDisplayed(this IWebDriver driver, IWebElement element)
        {
            return Wait(driver).Until(c => element.Displayed);
        }

        public static bool WaitUntilPageContainsTitle(this IWebDriver driver, string expectedTitle)
        {
            return Wait(driver).Until(c => driver.Title.Contains(expectedTitle, StringComparison.InvariantCultureIgnoreCase));
        }

        public static bool WaintUntilUrlChanged(this IWebDriver driver, string previousUrl)
        {
            return Wait(driver).Until(c => c.Url != previousUrl);
        }

        public static bool WaitUntilElementIsInteractable(this IWebDriver driver, IWebElement element)
        {
            return Wait(driver).Until(c => element.Displayed && element.Enabled);
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

        public static IWebElement GetElement(this IWebDriver driver, By locator)
        {
            IWebElement element = driver.FindElement(locator);
            return element;
        }

        public static IWebElement GetElement(this IWebElement parent, By locator)
        {
            IWebElement element = parent.FindElement(locator);
            return element;
        }

        public static List<IWebElement> GetElements(this IWebDriver driver, By locator)
        {
            List<IWebElement> elements = driver.FindElements(locator).ToList();
            return elements;
        }

        public static List<IWebElement> GetElements(this IWebElement parent, By locator)
        {
            List<IWebElement> elements = parent.FindElements(locator).ToList();
            return elements;
        }
    }
}
