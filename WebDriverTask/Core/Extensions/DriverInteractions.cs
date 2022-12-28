﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Pages;

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
    }
}
