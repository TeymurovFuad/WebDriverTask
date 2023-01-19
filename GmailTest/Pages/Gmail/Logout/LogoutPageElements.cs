using OpenQA.Selenium;
using WebDriverTask.Common.Pages;
using WebDriverTask.Utils.Extensions;

namespace GmailTest.Pages.Gmail.Logout
{
    public class LogoutPageElements : BasePage
    {
        IWebDriver webDriver { get; set; }
        public LogoutPageElements(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        public readonly By ChooseAnAccoutLabelLocator = By.XPath("//span[text()='Choose an account']");
        public IWebElement ChooseAnAccoutLabel => webDriver.GetElement(ChooseAnAccoutLabelLocator);
    }
}
