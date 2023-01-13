using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Utils.Extensions
{
    public static class DriverInteractions
    {
        public static void WaitPageToLoad(this IWebDriver driver, int secondsToWait = 5, Action? exceptedAction = null)
        {
            if (secondsToWait > 0 && driver != null)
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secondsToWait);
        }

        private static WebDriverWait Wait(IWebDriver driver, int waitTimeInSeconds = 5, params Type[]? exceptionTypesToIgnore)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));
            if (exceptionTypesToIgnore?.Length > 0)
                wait.IgnoreExceptionTypes(exceptionTypesToIgnore);
            return wait;
        }

        public static (IWebElement element, IWebDriver driver, bool isDisplayed)
            WaitUntilElementDisplayed(this IWebDriver webDriver, IWebElement webElement, params Type[]? ignoreExceptions)
        {
            bool displayed = Wait(webDriver, exceptionTypesToIgnore: ignoreExceptions).Until(c => webElement.Displayed);
            return (webElement, webDriver, displayed);
        }

        public static (IWebElement? element, IWebDriver driver, bool isDisplayed) WaitUntilElementDisplayed(this IWebDriver webDriver, By locator)
        {
            IWebElement? webElement = null;
            bool displayed = Wait(webDriver).Until(c => c.GetElement(locator).Displayed);
            if (displayed)
                webElement = webDriver.FindElement(locator);
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
            return Wait(driver).Until(c => c.Title.Contains(expectedTitle, StringComparison.InvariantCultureIgnoreCase));
        }

        public static bool WaintUntilUrlChanged(this IWebDriver driver, string previousUrl)
        {
            return Wait(driver).Until(c => c.Url != previousUrl);
        }

        public static bool WaintUntilUrlChanged(this IWebDriver driver, Action action)
        {
            string previousUrl = driver.Url;
            action();
            return Wait(driver).Until(c => c.Url != previousUrl);
        }

        public static IWebElement? WaitAndReturnUntilElementIsInteractable(this IWebDriver driver, IWebElement element)
        {
            bool interactable = Wait(driver).Until(c => element.Displayed && element.Enabled);
            if (!interactable)
            {
                return null;
            }
            return element;
        }

        public static void WaitUntilElementIsInteractable(this IWebDriver driver, By locator)
        {
            Wait(driver).Until(c =>
            {
                IWebElement element = c.GetElement(locator);
                return element.Displayed && element.Enabled;
            });
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

        public static IWebElement GetChild(this IWebElement parent, By locator)
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

        public static (int width, int height) JsGetViewportSize(this IWebDriver driver)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            int width, height;
            Dictionary<string, object> widthHeight = (Dictionary<string, object>)jsExecutor
                .ExecuteScript("var width=document.documentElement.clientWidth; var height=document.documentElement.clientHeight; return {width:width, height:height};");
            width = Convert.ToInt32(widthHeight["width"]);
            height = Convert.ToInt32(widthHeight["height"]);
            return (width, height);
        }
    }
}
