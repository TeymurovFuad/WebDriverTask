using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Pages.Gmail.Logout
{
    public class LogoutPageElements: BasePage
    {
        IWebDriver webDriver { get; set; }
        public LogoutPageElements(IWebDriver driver): base(driver)
        {
            webDriver = driver;
        }

        public readonly By ChooseAnAccoutLocator =  By.XPath("//span[text()='Choose an account']");
        public IWebElement ChooseAnAccout => webDriver.GetElement(ChooseAnAccoutLocator);
    }
}
