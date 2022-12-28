using OpenQA.Selenium;
using System.Reflection;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages
{
    public class BasePage : DriverManager
    {
        protected BasePage() { }

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
                        GetDriver().WaitUntilElementIsInteractable(element);
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

        public void SendValuesToElement(IWebElement element, string value)
        {
            if (element.isElementDisplayed())
                element.SendKeys(value);
        }

        public void WaitPageLoad(int seconds = 5)
        {
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public void HandleAlert(bool accept)
        {
            try
            {
                IAlert alert = GetDriver().SwitchTo().Alert();
                if (accept)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                GetDriver().SwitchTo().DefaultContent();
            }
            catch (NoAlertPresentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string IgnoreCaseInXPath(string partOrXpathToBeIgnored, string? property = "text()")
        {
            return $"contains(translate({property}, {partOrXpathToBeIgnored.ToLower()}, {partOrXpathToBeIgnored.ToUpper()}), {partOrXpathToBeIgnored})";
        }

        public string GetPageTitle()
        {
            return GetDriver().Title;
        }
    }
}
