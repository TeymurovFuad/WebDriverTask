using OpenQA.Selenium;
using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Pages.Gmail.Logout
{
    public class AccoutDialog: MainPage
    {
        public AccoutDialog() : base() { }

        public void OpenAccountDialog(string email)
        {
            IWebElement openAccountDialogButton = AccountDialogElements.OpenAccountDialogButton(email);
            if (isElementDisplayed(openAccountDialogButton))
            {
                openAccountDialogButton.Click();
            }
        }

        public AccoutDialog And()
        {
            return this;
        }

        public static void SwitchToAccountFrame()
        {
            Driver.SwitchToFrame(AccountDialogElements.AccountIFrame);
        }

        public void ClickSignoutButton()
        {
            IWebElement singoutButton = AccountDialogElements.SingOutButton;
            if (WaitUntilElementIsInteractable(singoutButton))
            {
                singoutButton.Click();
            }
            else
            {
                throw new Exception("Error on click signout button");
            }

        }
    }
}
