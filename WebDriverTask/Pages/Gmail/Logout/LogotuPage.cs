using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages.Gmail.Logout
{
    public class LogoutPage: BasePage
    {
        readonly LogoutPageElements _logoutPageElements;
        public LogoutPage()
        {
            _logoutPageElements = new LogoutPageElements();
        }
        public bool isLogoutPageDisplayed()
        {
            return _logoutPageElements.ChooseAnAccout.isElementDisplayed();
        }
    }
}
