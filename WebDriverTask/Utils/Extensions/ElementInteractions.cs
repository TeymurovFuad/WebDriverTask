using OpenQA.Selenium;
using WebDriverTask.Utils.Extensions;

namespace WebDriverTask.Core.Extensions
{
    public static class ElementInteractions
    {
        public static void SendValuesToElement(this IWebElement element, string value)
        {
            if (element.isElementDisplayed())
                element.SendKeys(value);
        }

        public static bool isElementDisplayed(this IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public static bool isElementDisplayed(this IWebDriver driver, By locator)
        {
            try
            {
                return driver.WaitUntilElementDisplayed(locator).isDisplayed;
            }
            catch
            {
                return false;
            }
        }

        public static bool isElementDisplayed(this IWebDriver driver, IWebElement element)
        {
            try
            {
                return driver.WaitUntilElementDisplayed(element).isDisplayed;
            }
            catch
            {
                return false;
            }
        }

        public static bool isContainsChild(this IWebElement parent, By childLocator)
        {
            try
            {
                return parent.GetElements(childLocator).Count > 0;
            }
            catch
            {
                return false;
            }
        }

        public static void HandleAlert(this IWebDriver driver, bool accept)
        {
            IAlert alert = driver.SwitchTo().Alert();
            if (accept)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
            driver.SwitchTo().DefaultContent();
        }

        public static string GetLocatorType(this By locator)
        {
            return StringifyLocator(locator).First().Trim();
        }

        public static string GetLocatorValue(this By locator)
        {
            return StringifyLocator(locator).Reverse().First().Trim();
        }

        private static string[] StringifyLocator(By locator)
        {
            //{By.locatorType: locatoryValue}
            return locator.ToString().Replace("By.", "").Split(new char[] {':'}, 2);
        }

        public static void ClickElement(this IWebElement element, IWebDriver driver)
        {
            element.Click();
        }

        public static void JsClick(this IWebDriver driver, By locator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            string script = $"$x(\"{locator.GetLocatorValue()}\")[0].click();";
            driver.JsClick(locatorValue: locator.GetLocatorValue(), locatoryType: locator.GetLocatorType());
            jsExecutor.ExecuteScript(script);
        }

        public static void JsClick(this IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", element);
        }

        public static void JsClick(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", element);
        }

        public static void JsClick(this IWebDriver driver, string locatorValue, string locatoryType)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            string? xPath = null;
            switch (locatoryType.ToLower())
            {
                case "id":
                    locatoryType = "Id";
                    break;
                case "css":
                case "classname":
                    locatoryType = "ClassName";
                    break;
                case "tag":
                case "tagname":
                    locatoryType = "TagName";
                    break;
                case "name":
                    locatoryType = "Name";
                    break;
                case "xpath":
                    xPath = $"$x('{locatorValue}')[0]";
                    break;
                default:
                    throw new NotImplementedException();
            }
            string locator = $"document.GetElementBy{locatoryType}({locatorValue})";
            jsExecutor.ExecuteScript($"{xPath??locator}.click();");
        }


        public static ((int x, int y) position, (int width, int height) size, (int left, int right) leftRight, (int top, int bottom) topBottom) 
            JsGetElementOffset(this IWebDriver driver, IWebElement element)
        {
            int x, y, width, height, left, right, top, bottom;
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            Dictionary<string, object> rect = (Dictionary<string, object>)jsExecutor.ExecuteScript("return arguments[0].getBoundingClientRect();", element);
            x = Convert.ToInt32(rect["x"]);
            y = Convert.ToInt32(rect["y"]);
            width = Convert.ToInt32(rect["width"]);
            height = Convert.ToInt32(rect["height"]);
            left = Convert.ToInt32(rect["left"]);
            right = Convert.ToInt32(rect["right"]);
            top = Convert.ToInt32(rect["top"]);
            bottom = Convert.ToInt32(rect["bottom"]);
            return ((x, y), (width, height), (left, right), (top, bottom));
        }
    }
}
