using OpenQA.Selenium;
using WebDriverTask.Utils.Extensions;

namespace WebDriverTask.Pages.Gmail.Dialogs.Message
{
    public class MessageDialog : MessageDialogElements, IPage
    {
        IWebDriver webDriver { get; set; }
        public MessageDialog(IWebDriver driver): base(driver)
        {
            webDriver= driver;
        }

        public void MailTo(params string[] addressTo)
        {
            string receivers = string.Join(",", addressTo);
            webDriver.WaitUntilElementIsInteractable(To);
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
                webDriver.WaitUntilElementHidden(saveAndCloseButton);
            }
        }
    }
}
