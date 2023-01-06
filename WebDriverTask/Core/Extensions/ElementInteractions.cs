using NUnit.Framework;
using OpenQA.Selenium;
using System.Diagnostics.CodeAnalysis;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Core.Extensions
{
    public static class BaseInteractions
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
                return driver.GetElements(locator).Count > 0;
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
            jsExecutor.ExecuteScript("arguments[0].click();");
        }

        public static void JsClick(this IWebElement element, IWebDriver driver)
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
            jsExecutor.ExecuteScript($"{xPath??locator}.click()");
        }
    }
}
