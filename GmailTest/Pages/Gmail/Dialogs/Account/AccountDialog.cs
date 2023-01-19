using OpenQA.Selenium;
using WebDriverTask.Common.Pages;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Utils.Extensions;

namespace GmailTest.Pages.Gmail.Dialogs.Account
{
    public class AccountDialog : AccountDialogElements, IPage
    {
        IWebDriver webDriver { get; set; }
        public AccountDialog(IWebDriver driver) : base(driver)
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
            ClickElement(SingOutButtonLocator);
        }
    }
}
