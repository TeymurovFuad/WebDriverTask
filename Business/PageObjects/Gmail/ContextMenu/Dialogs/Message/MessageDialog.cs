using Core.Common.Pages;
using Core.Extensions;
using Core.Utils.Extensions;
using Core.Utils.LogConfig;
using OpenQA.Selenium;

namespace Business.PageObjects.Gmail.ContextMenu.Dialogs.Message
{
    public class MessageDialog : MessageDialogElements, IPage
    {
        IWebDriver webDriver { get; set; }
        public MessageDialog(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        public void MailTo(params string[] addressTo)
        {
            string receivers = string.Join(",", addressTo);
            webDriver.WaitUntilElementIsInteractable(ToLocator);
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

        public void FillMailData(string receiver, string subject, string body)
        {
            MailTo(receiver);
            MailSubject(subject);
            MailBody(body);
        }

        public void CloseMailDialog(string subject)
        {
            try
            {
                webDriver.JsClick(SaveAndCloseButton(subject));
            }
            catch (NoSuchElementException)
            {
                SaveAndCloseButton(subject).Click();
            }
            catch (Exception e)
            {
                MessageLogger.GetLogger().Error(e.Message);
            }
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
