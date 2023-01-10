using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Pages;

namespace GmailTest.Pages.Gmail.Logout
{
    public class LogoutPage: LogoutPageElements, IPage
    {
        IWebDriver webDriver { get; set; }

        public LogoutPage(IWebDriver driver): base(driver)
        {
            webDriver = driver;
        }

        public bool isLogoutPageDisplayed()
        {
            return ChooseAnAccoutLabel.isElementDisplayed();
        }
    }
}
