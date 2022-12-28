using OpenQA.Selenium;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages.Gmail.Dialogs.Message
{
    public class MessageDialog : BasePage
    {
        public readonly MessageDialogElements messageDialogElements;
        public MessageDialog()
        {
            messageDialogElements = new MessageDialogElements();
        }
        public void To(params string[] addressTo)
        {
            string receivers = string.Join(",", addressTo);
            messageDialogElements.To.SendKeys(receivers);
        }

        public void Subject(string addressTo)
        {
            messageDialogElements.Subject.SendKeys(addressTo);
        }

        public void Body(string addressTo)
        {
            messageDialogElements.Body.SendKeys(addressTo);
        }

        public void Send()
        {
            messageDialogElements.SendButton.Click();
        }

        public void CloseAllMailDialogs()
        {
            foreach (IWebElement saveAndCloseButton in messageDialogElements.SaveAndCloseButtons)
            {
                saveAndCloseButton.Click();
            }
        }
    }
}
