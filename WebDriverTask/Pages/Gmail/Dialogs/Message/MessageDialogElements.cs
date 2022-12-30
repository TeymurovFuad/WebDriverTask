using OpenQA.Selenium;
using WebDriverTask.Core.Helpers;

namespace WebDriverTask.Pages.Gmail.Dialogs.Message
{
    public class MessageDialogElements : BasePage
    {
        IWebDriver webDriver { get; set; }
        public MessageDialogElements(IWebDriver driver): base(driver)
        {
            webDriver = driver;
        }

        private const string _newMailDialogHeader = "New Message";
        private const string _mailDialogByHeaderXPath = "//h2[div[text()='Compose:'] and div/span[text()='{0}']]";
        private const string _allMailDialogsXPath = "//h2[div[text()='Compose:']]";

        public const string ToXPath = "//div[@name='to']//input";
        public IWebElement To => webDriver.FindElements(By.XPath(ToXPath)).First();

        public const string SubjectXPath = "//input[@name='subjectbox']";
        public IWebElement Subject => webDriver.FindElements(By.XPath(SubjectXPath)).First();

        public const string BodyXPath = "//div[@aria-label='Message Body']";
        public IWebElement Body => webDriver.FindElements(By.XPath(BodyXPath)).First();

        public const string SendButtonXPath = "//div[@role='button' and text()='Send']";
        public IWebElement SendButton => webDriver.FindElements(By.XPath(SendButtonXPath)).First();

        public const string SaveAndCloseButtonsXPath = "//img[@aria-label='Save & close']";
        public List<IWebElement> SaveAndCloseButtons => webDriver.FindElements(By.XPath(SaveAndCloseButtonsXPath)).ToList();


        public List<IWebElement> MailDialogsByHeader(string dialogHeader)
        {
            string pathToDialog = StringHelper.FormatString(_mailDialogByHeaderXPath, dialogHeader)!;
            return webDriver.FindElements(By.XPath(pathToDialog)).ToList();
        }

        public List<IWebElement> NewMailDialogs()
        {
            string pathToDialog = StringHelper.FormatString(_mailDialogByHeaderXPath, _newMailDialogHeader)!;
            return webDriver.FindElements(By.XPath(pathToDialog)).ToList();
        }

        public List<IWebElement> AllMailDialogs()
        {
            return webDriver.FindElements(By.XPath(_allMailDialogsXPath)).ToList();
        }

        public IWebElement GetMailDialog(string? mailSubject=null)
        {
            string pathToSpecifiedMessageDialog = StringHelper.FormatString(_mailDialogByHeaderXPath, mailSubject ?? _newMailDialogHeader)!;
            return webDriver.FindElement(By.XPath(pathToSpecifiedMessageDialog));
        }
    }
}
