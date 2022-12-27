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
            WaitUntilElementDisplayed(_logoutPageElements.ChooseAnAccout);
            return isElementDisplayed(_logoutPageElements.ChooseAnAccout);
        }
    }
}
