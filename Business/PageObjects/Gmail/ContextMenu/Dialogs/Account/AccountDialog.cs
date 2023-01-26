using Core.Common.Pages;
using Core.Extensions;
using Core.Utils.Extensions;
using OpenQA.Selenium;

namespace Business.PageObjects.Gmail.ContextMenu.Dialogs.Account
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
