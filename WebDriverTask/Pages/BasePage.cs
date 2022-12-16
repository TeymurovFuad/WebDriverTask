using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Reflection;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages
{
    public class BasePage : DriverManager
    {
        protected BasePage() { }

        public void ClickElement(IWebElement element, bool condition = true)
        {
            if (condition && isElementDisplayed(element))
            {
                bool success = false;
                int retry = 5;
                do
                {
                    try
                    {
                        WaitUntilElementIsInteractable(element);
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
            if (isElementDisplayed(element))
                element.SendKeys(value);
        }

        public void WaitPageLoad(int seconds = 5)
        {
            Core.WebDriver.Driver.GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static bool isElementDisplayed(IWebElement element)
        {
            try
            {
                WaitUntilElementDisplayed(element);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool isElementDisplayed(By locator)
        {
            try
            {
                return Core.WebDriver.Driver.GetDriver().FindElements(locator).Count > 0;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool isElementDisplayed(By locator, IWebElement parent)
        {
            try
            {
                return parent.FindElements(locator).Count > 0;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void HandleAlert(bool accept)
        {
            try
            {
                IAlert alert = Core.WebDriver.Driver.GetDriver().SwitchTo().Alert();
                if (accept)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                Core.WebDriver.Driver.GetDriver().SwitchTo().DefaultContent();
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

        public string GetLocatorFromFindsByAttribute<T>(IWebElement element) where T : class
        {
            string locator = string.Empty;
            MemberInfo memberInfo = typeof(T).GetMember(element.GetType().Name)[0];
            if (memberInfo.GetCustomAttribute(typeof(FindsByAttribute)) is FindsByAttribute findsByAttribute)
            {
                locator = findsByAttribute.Using;
            }
            return locator;
        }

        public static string GetPageTitle()
        {
            return Core.WebDriver.Driver.GetDriver().Title;
        }
    }
}
