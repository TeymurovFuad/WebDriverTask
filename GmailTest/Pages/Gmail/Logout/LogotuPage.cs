using OpenQA.Selenium;
using WebDriverTask.Common.Pages;
using WebDriverTask.Core.Extensions;

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
