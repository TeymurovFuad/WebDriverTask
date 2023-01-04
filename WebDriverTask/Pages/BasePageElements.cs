using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Pages
{
    public class BasePageElements
    {
        private readonly IWebDriver _webDriver;
        protected BasePageElements(IWebDriver driver)
        {
            _webDriver = driver;
        }

        public static By TitleLocator => By.XPath("html/head/title");
        public IWebElement Title => _webDriver.GetElement(TitleLocator);
    }
}
