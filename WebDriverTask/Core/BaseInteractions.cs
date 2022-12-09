using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.WebDriverConfigs;

namespace WebDriverTask.Core
{
    public class BaseInteractions: WebDriverManager
    {
        public IWebDriver driver { get; set; }

        public BaseInteractions(IWebDriver driver)
        {
            this.driver = driver;
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
                        WebDriverManager.WaintUntilElementDisplayed(locator);
                        driver.FindElement(locator).Click();
                        success = true;
                    }
                    catch (StaleElementReferenceException e)
                    {
                        success = false;
                    }
                    retry--;
                } while (!success && retry > 0);
            }
        }

        public void SendValuesToElement(By locator, string value)
        {
            if (isElementDisplayed(locator))
                driver!.FindElement(locator).SendKeys(value);
        }

        public void WaitPageLoad(int seconds = 5)
        {
            driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public bool isElementDisplayed(By locator)
        {
            try
            {
                driver!.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void HandleAlert(bool accept = true)
        {
            try
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
            catch (NoAlertPresentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
