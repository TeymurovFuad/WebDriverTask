using OpenQA.Selenium;
using System.Reflection;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages
{
    public abstract class BasePage
    {
        private IWebDriver webDriver;

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

        public void HandleAlert(bool accept)
        {
            try
            {
                IAlert alert = webDriver.SwitchTo().Alert();
                if (accept)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                webDriver.SwitchTo().DefaultContent();
            }
            catch (NoAlertPresentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string IgnoreCaseInXPath(string partOrXpathToBeIgnored, string? property = "text()")
        {
            return $"contains(translate({property}, {partOrXpathToBeIgnored.ToLower()}, {partOrXpathToBeIgnored.Capitalise()}), {partOrXpathToBeIgnored})";
        }
    }
}
