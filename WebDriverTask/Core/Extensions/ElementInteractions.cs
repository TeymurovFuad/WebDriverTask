﻿using NUnit.Framework;
using OpenQA.Selenium;
using System.Diagnostics.CodeAnalysis;

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
    }
}
