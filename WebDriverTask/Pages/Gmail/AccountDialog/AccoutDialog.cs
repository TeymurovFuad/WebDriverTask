﻿using OpenQA.Selenium;

namespace WebDriverTask.Pages.Gmail.Logout.AccountDialog
{
    public class AccoutDialog : MainPage
    {
        public static void OpenAccountDialog(string email)
        {
            IWebElement openAccountDialogButton = AccountDialogElements.OpenAccountDialogButton(email);
            if (isElementDisplayed(openAccountDialogButton))
            {
                openAccountDialogButton.Click();
            }
        }

        public static void SwitchToAccountFrame()
        {
            Core.WebDriver.Driver.SwitchToFrame(AccountDialogElements.AccountIFrame);
        }

        public static void ClickSignoutButton()
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
