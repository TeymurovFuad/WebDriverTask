using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Core;

namespace WebDriverTask.Pages
{
    public abstract class BasePage: BaseInteractions
    {
        IWebDriver driver;
        public BasePage(Browser browser)
        {
            driver = new DriverFactory().CreateDriver(browser, arguments);
        }
    }
}
