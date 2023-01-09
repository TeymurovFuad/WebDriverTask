using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Pages.Gmail.Logout
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
