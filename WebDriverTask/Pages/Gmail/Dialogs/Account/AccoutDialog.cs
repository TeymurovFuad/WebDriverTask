using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages.Gmail.Dialogs.Account
{
    public class AccoutDialog : BasePage
    {
        readonly AccountDialogElements _accountDialogElements;
        public AccoutDialog()
        {
            _accountDialogElements = new AccountDialogElements();
        }

        public void OpenAccountDialog(string email)
        {
            IWebElement openAccountDialogButton = _accountDialogElements.OpenAccountDialogButton(email);
            if (openAccountDialogButton.isElementDisplayed())
            {
                openAccountDialogButton.Click();
            }
        }

        public void SwitchToAccountFrame()
        {
            DriverInstance().SwitchToFrame(_accountDialogElements.AccountIFrame);
        }

        public void ClickSignoutButton()
        {
            IWebElement signoutButton = _accountDialogElements.SingOutButton;
            if (signoutButton.isElementDisplayed())
            {
                signoutButton.Click();
            }
            else
            {
                throw new Exception("Error on click signout button");
            }
        }
    }
}
