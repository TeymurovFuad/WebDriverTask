﻿using OpenQA.Selenium;

namespace WebDriverTask.Pages.Gmail.MailDialog
{
    public class MessageDialog
    {
        public static void To(params string[] addressTo)
        {
            string receivers = string.Join(",", addressTo);
            MessageDialogElements.To.SendKeys(receivers);
        }

        public static void Subject(string addressTo)
        {
            MessageDialogElements.Subject.SendKeys(addressTo);
        }

        public static void Body(string addressTo)
        {
            MessageDialogElements.Body.SendKeys(addressTo);
        }

        public static void Send()
        {
            MessageDialogElements.SendButton.Click();
        }

        public static void CloseAllMailDialogs()
        {
            foreach (IWebElement saveAndCloseButton in MessageDialogElements.SaveAndCloseButtons)
            {
                saveAndCloseButton.Click();
            }
        }

        public static bool isMailDialogDisplayed(string? mailSubject=null)
        {
            return BasePage.isElementDisplayed(By.XPath(MessageDialogElements.PathToMailDialog(mailSubject)));
        }
    }
}
