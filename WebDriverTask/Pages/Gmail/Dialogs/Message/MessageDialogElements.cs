using OpenQA.Selenium;
using WebDriverTask.Core.Helpers;

namespace WebDriverTask.Pages.Gmail.Dialogs.Message
{
    public class MessageDialogElements : BaseElements
    {
        private const string _newMailDialogHeader = "New Message";
        private const string _mailDialogXPath = "//h2[div[text()='Compose:'] and div/span[text()='{0}']]";

        public const string ToXPath = "//div[@name='to']//input";
        public IWebElement To => GetDriver().FindElements(By.XPath(ToXPath)).First();

        public const string SubjectXPath = "//input[@name='subjectbox']";
        public IWebElement Subject => GetDriver().FindElements(By.XPath(SubjectXPath)).First();

        public const string BodyXPath = "//div[@aria-label='Message Body']";
        public IWebElement Body => GetDriver().FindElements(By.XPath(BodyXPath)).First();

        public const string SendButtonXPath = "//div[@role='button' and text()='Send']";
        public IWebElement SendButton => GetDriver().FindElements(By.XPath(SendButtonXPath)).First();

        public const string SaveAndCloseButtonsXPath = "//img[@aria-label='Save & close']";
        public List<IWebElement> SaveAndCloseButtons => GetDriver().FindElements(By.XPath(SaveAndCloseButtonsXPath)).ToList();


        public List<IWebElement> MailDialogs(string dialogHeader)
        {
            string pathToDialog = StringHelper.FormatString(_mailDialogXPath, dialogHeader)!;
            return GetDriver().FindElements(By.XPath(pathToDialog)).ToList();
        }

        public List<IWebElement> MailDialogs()
        {
            string pathToDialog = StringHelper.FormatString(_mailDialogXPath, _newMailDialogHeader)!;
            return GetDriver().FindElements(By.XPath(pathToDialog)).ToList();
        }

        public string PathToMailDialog(string mailSubject)
        {
            return StringHelper.FormatString(_mailDialogXPath, mailSubject ?? _newMailDialogHeader)!;
        }
    }
}
