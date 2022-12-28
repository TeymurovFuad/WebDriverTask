﻿using OpenQA.Selenium;

namespace WebDriverTask.Pages.Gmail.Dialogs.Account
{
    public class AccoutDialog : MainPage
    {
        readonly AccountDialogElements _accountDialogElements;
        public AccoutDialog()
        {
            _accountDialogElements = new AccountDialogElements();
        }

        public void OpenAccountDialog(string email)
        {
            IWebElement openAccountDialogButton = _accountDialogElements.OpenAccountDialogButton(email);
            if (isElementDisplayed(openAccountDialogButton))
            {
                openAccountDialogButton.Click();
            }
        }

        public void SwitchToAccountFrame()
        {
            SwitchToFrame(_accountDialogElements.AccountIFrame);
        }

        public void ClickSignoutButton()
        {
            IWebElement singoutButton = _accountDialogElements.SingOutButton;
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