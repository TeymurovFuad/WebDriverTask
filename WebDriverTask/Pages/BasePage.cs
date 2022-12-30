using OpenQA.Selenium;
using System.Reflection;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages
{
    public abstract class BasePage
    {
        private IWebDriver webDriver;
        private IAlert alert;

        protected IWebDriver GetDriverInstance()
        {
            return webDriver;
        }

        public void ClickElement(IWebElement element, bool condition = true)
        {
            if (condition && element.isElementDisplayed())
            {
                bool success = false;
                int retry = 5;
                do
                {
                    try
                    {
                        webDriver.WaitUntilElementIsInteractable(element);
                        element.Click();
                        success = true;
                    }
                    catch (StaleElementReferenceException)
                    {
                        success = false;
                    }
                    retry--;
                } while (!success && retry > 0);
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
            try
            {
                alert = webDriver.SwitchTo().Alert();
                return true;
            }
            catch(NoAlertPresentException noAlertException)
            {
                return false;
            }
        }

        public string IgnoreCaseInXPath(string partOrXpathToBeIgnored, string? property = "text()")
        {
            return $"contains(translate({property}, {partOrXpathToBeIgnored.ToLower()}, {partOrXpathToBeIgnored.Capitalise()}), {partOrXpathToBeIgnored})";
        }
    }
}
