using Business.PageObjects.Gmail.ContextMenu.Dialogs.Message;
using Core.Utils.Extensions;
using OpenQA.Selenium;

namespace Business.PageObjects.Gmail.Folders.Sent
{
    public class SentFolderElements : MessageDialog
    {
        IWebDriver webDriver;
        public SentFolderElements(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        protected readonly string FolderName = "Sent";

        public By NoSentMessagesLocator { get; set; } = By.XPath("td[text()='No sent messages! ']");
        public IWebElement NoSentMessages => webDriver.JsGetElement(NoSentMessagesLocator);

        public By SentMailsLocator => By.XPath("//div[text()='To: ']/ancestor::tr");
        public List<IWebElement> SentMails => webDriver.GetElements(SentMailsLocator);

        public By SentMailBySubjectLocator(string subjectOrBody) => By.XPath($"//span[text()='{subjectOrBody}' and parent::span]");
        public List<IWebElement> GetSentMailsBySubject(string subjectObBody) => webDriver.GetElements(SentMailBySubjectLocator(subjectObBody));
        public IWebElement? GetSentMailBySubject(string subjectObBody) => webDriver.GetElement(SentMailBySubjectLocator(subjectObBody));
    }
}
