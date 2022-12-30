﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverTask.Core.CustomExceptions;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Pages
{
    public abstract class BasePage
    {
        private IWebDriver webDriver;
        private IAlert alert;

        public BasePage(IWebDriver driver)
        {
            webDriver = driver;
        }

        public void ClickElement(IWebElement element, bool condition = true)
        {
            if (webDriver.WaitUntilElementIsInteractable(element))
            {
                element.Click();
            }
            else
            {
                throw new ElementException("Not able to click an element");
            }
        }

        public void AlerDismiss()
        {
            if (isAlertExists())
            {
                alert.Dismiss();
            }
        }

        public void AlertAccept()
        {
            if (isAlertExists())
            {
                alert.Accept();
            }
        }

        public bool isAlertExists()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(1500));
            wait.Until(a => alert = webDriver.SwitchTo().Alert());
            if(alert!=null)
            {
                return true;
            }
            return false;
        }

        public string IgnoreCaseInXPath(string partOrXpathToBeIgnored, string? property = "text()")
        {
            return $"contains(translate({property}, {partOrXpathToBeIgnored.ToLower()}, {partOrXpathToBeIgnored.Capitalise()}), {partOrXpathToBeIgnored})";
        }
    }
}
