using OpenQA.Selenium;
using WebDriverTask.Core.BrowserConfigs;
using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Pages
{
    public class BasePage : DriverManager
    {
        public BasePage(BrowserType browser): base(browser)
        {
        }

        public void ClickElement(IWebElement element, bool condition = true)
        {
            if (condition && isElementDisplayed(element))
            {
                bool success=false;
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
            Driver.GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public bool isElementDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
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
                IAlert alert = Driver.GetDriver().SwitchTo().Alert();
                if (accept)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                Driver.GetDriver().SwitchTo().DefaultContent();
            }
            catch (NoAlertPresentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
