using OpenQA.Selenium;
using WebDriverTask.Utils.Extensions;

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
