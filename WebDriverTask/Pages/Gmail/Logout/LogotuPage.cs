using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Pages.Gmail.Logout
{
    public class LogoutPage: LogoutPageElements
    {
        public LogoutPage(IWebDriver driver): base(driver) { }

        public bool isLogoutPageDisplayed()
        {
            return ChooseAnAccout.isElementDisplayed();
        }
    }
}
