using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
