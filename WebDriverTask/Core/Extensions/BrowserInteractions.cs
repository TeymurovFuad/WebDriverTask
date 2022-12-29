using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask.Core.Extensions
{
    public static class BrowserInteractions
    {
        public static void MaximizeBrowser(this IWebDriver driver)
        {
            if (driver != null)
                driver.Manage().Window.Maximize();
        }

        public static void DeleteAllCookies(this IWebDriver driver)
        {
            if (driver != null)
                driver!.Manage().Cookies.DeleteAllCookies();
        }
    }
}
