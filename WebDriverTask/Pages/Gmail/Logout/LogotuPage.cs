namespace WebDriverTask.Pages.Gmail.Logout
{
    public class LogotuPage: MainPage
    {
        public static bool isLogoutPageDisplayed()
        {
            WaitUntilElementDisplayed(LogoutPageElements.ChooseAnAccout);
            return isElementDisplayed(LogoutPageElements.ChooseAnAccout);
        }
    }
}
