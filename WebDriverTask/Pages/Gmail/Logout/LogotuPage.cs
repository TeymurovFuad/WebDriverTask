using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Pages.Gmail.Logout
{
    public class LogoutPage: MainPage
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
