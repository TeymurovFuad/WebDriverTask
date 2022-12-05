using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask
{
    public class PageInteractions
    {
        private IWebDriver _driver;

        public PageInteractions()
        {
            _driver = DriverManager.Instance();
        }

        public void ClickElement(By locator, bool condition = true)
        {
            if (condition && isElementDisplayed(locator))
            {
                bool success;
                int retry = 5;
                do
                {
                    try
                    {
                        DriverManager.WaintUntilElementDisplayed(locator);
                        _driver.FindElement(locator).Click();
                        success = true;
                    }
                    catch(StaleElementReferenceException e)
                    {
                        success = false;
                    }
                    retry--;
                }while(!success && retry > 0);
            }
        }

        public void SendValuesToElement(By locator, string value)
        {
            if (isElementDisplayed(locator))
                _driver!.FindElement(locator).SendKeys(value);
        }

        public void WaitPageLoad(int seconds = 5)
        {
            _driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public bool isElementDisplayed(By locator)
        {
            try
            {
                _driver!.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
