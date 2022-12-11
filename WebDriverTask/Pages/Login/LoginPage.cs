using WebDriverTask.Core.BrowserConfigs;

namespace WebDriverTask.Pages.Login
{
    public class LoginPage: BasePage
    {
        public LoginPage() : base(BrowserType.Chrome)
        {
            AddArguments("--incognito", "--somesetting");
        }

        public void xxx()
        {
        }
    }
}
