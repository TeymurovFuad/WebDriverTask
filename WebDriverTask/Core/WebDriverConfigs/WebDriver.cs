using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask.Core.WebDriverConfigs
{
    public static class WebDriver
    {
        private static IWebDriver? _webDriver = null;

        public static IWebDriver GetDriver()
        {
            if (_webDriver == null)
            {
                throw new NullReferenceException($"Webdriver is not set");
            }
            return _webDriver;
        }

        public static void SetWebDriver(IWebDriver driver)
        {
            _webDriver = driver;
        }
    }
}
