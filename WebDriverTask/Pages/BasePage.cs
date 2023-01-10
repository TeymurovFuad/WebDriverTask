﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverTask.Core.CustomExceptions;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Pages
{
    public abstract class BasePage: BasePageElements
    {
        protected IWebDriver webDriver { get; set; }
        private IAlert alert;

        public BasePage(IWebDriver driver): base(driver)
        {
            webDriver = driver;
        }

        public void ClickElement(IWebElement element, bool condition = true)
        {
            if (webDriver.WaitUntilElementIsInteractable(element)!=null)
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

        public string AlertText()
        {
            if (isAlertExists())
            {
                return alert.Text;
            }
            return string.Empty;
        }

        public bool isAlertExists()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(1500));
                wait.Until(a => alert = webDriver.SwitchTo().Alert());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string IgnoreCaseInXPath(string partOrXpathToBeIgnored, string? property = "text()")
        {
            return $"contains(translate({property}, {partOrXpathToBeIgnored.ToLower()}, {partOrXpathToBeIgnored.Capitalise()}), {partOrXpathToBeIgnored})";
        }

        public bool isTitleDisplayed(string title)
        {
            return webDriver.WaitUntilPageContainsTitle(expectedTitle: title);
        }
    }
}
