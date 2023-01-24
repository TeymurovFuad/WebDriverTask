using OpenQA.Selenium;
using Core.Utils.Extensions;

namespace Core.Common.Pages
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
