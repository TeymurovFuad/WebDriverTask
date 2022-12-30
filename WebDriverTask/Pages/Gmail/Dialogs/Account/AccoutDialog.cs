using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Pages.Gmail.Dialogs.Account
{
    public class AccoutDialog : AccountDialogElements
    {
        IWebDriver webDriver { get; set; }
        public AccoutDialog(IWebDriver driver): base(driver)
        {
            webDriver = driver;
        }


        public void OpenAccountDialog(string email)
        {
            IWebElement openAccountDialogButton = OpenAccountDialogButton(email);
            if (openAccountDialogButton.isElementDisplayed())
            {
                openAccountDialogButton.Click();
            }
        }

        public void SwitchToAccountFrame()
        {
            webDriver.SwitchToFrame(AccountIFrame);
        }

        public void ClickSignOut()
        {
            ClickElement(SignOutButton);
        }
    }
}
