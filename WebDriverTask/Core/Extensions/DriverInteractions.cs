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

        public static (IWebElement element, IWebDriver driver, bool isDisplayed) WaitUntilElementDisplayed(this IWebDriver webDriver, IWebElement webElement)
        {
            bool displayed = Wait(webDriver).Until(c => webElement.Displayed);
            return (webElement, webDriver, displayed);
        }

        public static (IWebElement element, IWebDriver driver, bool isDisplayed) WaitUntilElementDisplayed(this IWebElement webElement, IWebDriver webDriver)
        {
            bool displayed = Wait(webDriver).Until(c => webElement.Displayed);
            return (webElement, webDriver, displayed);
        }

        public static bool WaitUntilElementHidden(this IWebDriver driver, IWebElement element)
        {
            return Wait(driver).Until(c => !element.isElementDisplayed());
        }

        public static bool WaitUntilPageContainsTitle(this IWebDriver driver, string expectedTitle)
        {
            return Wait(driver).Until(c => driver.Title.Contains(expectedTitle, StringComparison.InvariantCultureIgnoreCase));
        }

        public static bool WaintUntilUrlChanged(this IWebDriver driver, string previousUrl)
        {
            return Wait(driver).Until(c => c.Url != previousUrl);
        }

        public static IWebElement? WaitUntilElementIsInteractable(this IWebDriver driver, IWebElement element)
        {
            bool interactable = Wait(driver).Until(c => element.Displayed && element.Enabled);
            if (!interactable)
            {
                return null;
            }
            return element;
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

        public static IWebElement JsGetElement(this IWebDriver driver, By locator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            IWebElement element;
            string locatorValue = locator.GetLocatorValue();
            string locatorType = locator.GetLocatorType();
            string? xPath = null;
            string script;
            switch (locatorType.ToLower())
            {
                case "id":
                    locatorType = "Id";
                    break;
                case "css":
                case "classname":
                    locatorType = "ClassName";
                    break;
                case "tag":
                case "tagname":
                    locatorType = "TagName";
                    break;
                case "name":
                    locatorType = "Name";
                    break;
                case "xpath":
                    xPath = locatorValue;
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (xPath != null)
            {
                script = $"return document.evaluate(\"{xPath}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;";
                element = (IWebElement)jsExecutor.ExecuteScript(script);
            }
            else
            {
                script = $"document.GetElementBy{locatorType}({locatorValue})";
                element = (IWebElement)jsExecutor.ExecuteScript(script);
            }
            return element;
        }

        public static List<IWebElement> JsGetElements(this IWebDriver driver, By locator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            List<IWebElement> elements;
            string locatorValue = locator.GetLocatorValue();
            string locatorType = locator.GetLocatorType();
            string? xPath = null;
            string script;
            switch (locatorType.ToLower())
            {
                case "css":
                case "classname":
                    locatorType = "ClassName";
                    break;
                case "tag":
                case "tagname":
                    locatorType = "TagName";
                    break;
                case "name":
                    locatorType = "Name";
                    break;
                case "xpath":
                    xPath = locatorValue;
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (xPath != null)
            {
                script = $"return document.evaluate(\"{xPath}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;";
                elements = (List<IWebElement>)jsExecutor.ExecuteScript(script);
            }
            else
            {
                script = $"document.GetElementBy{locatorType}({locatorValue})";
                elements = (List<IWebElement>)jsExecutor.ExecuteScript(script);
            }
            return elements;
        }

        public static (int width, int height) JsGetWindowSize(this IWebDriver driver)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            int width, height;
            Dictionary<string, object> widthHeight = (Dictionary<string, object>)jsExecutor
                .ExecuteScript("var width=window.innerWidth; var height=window.innerHeight; return {width:width, height:height};");
            width = Convert.ToInt32(widthHeight["width"]);
            height = Convert.ToInt32(widthHeight["height"]);
            return (width, height);
        }
    }
}
