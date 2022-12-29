﻿using OpenQA.Selenium;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages.Gmail.Dialogs.Message
{
    public class MessageDialog : MessageDialogElements
    {
        public MessageDialog(IWebDriver driver): base(driver) { }

        public void MailTo(params string[] addressTo)
        {
            string receivers = string.Join(",", addressTo);
            To.SendKeys(receivers);
        }

        public void MailSubject(string addressTo)
        {
            Subject.SendKeys(addressTo);
        }

        public void MailBody(string addressTo)
        {
            Body.SendKeys(addressTo);
        }

        public void Send()
        {
            SendButton.Click();
        }

        public void CloseAllMailDialogs()
        {
            foreach (IWebElement saveAndCloseButton in SaveAndCloseButtons)
            {
                saveAndCloseButton.Click();
            }
        }
    }
}
