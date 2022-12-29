using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Core.Extensions
{
    public static class BaseInteractions
    {
        public static void ClickElement<TDriver>(this IWebElement element, [AllowNull] bool condition)
            where TDriver : IWebDriver, new()
        {
            TDriver driver = new();
            driver.WaitUntilElementIsInteractable(element);
            element.Click();
        }

        public static void SendValuesToElement(this IWebElement element, string value)
        {
            if (element.isElementDisplayed())
                element.SendKeys(value);
        }

        public static bool isElementDisplayed(this IWebElement element)
        {
            return element.Displayed;
        }

        public static bool isElementDisplayed(this IWebDriver driver, By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }

        public static bool isContainsChild(this IWebElement parent, By childLocator)
        {
            return parent.FindElements(childLocator).Count > 0;
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
    }
}
