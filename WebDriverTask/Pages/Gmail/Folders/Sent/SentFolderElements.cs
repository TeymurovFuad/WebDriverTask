using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Pages.Gmail.Dialogs.Message;

namespace WebDriverTask.Pages.Gmail.Folders.Sent
{
    public class SentFolderElements: MessageDialog
    {
        IWebDriver webDriver;
        public SentFolderElements(IWebDriver driver): base(driver)
        {
            webDriver = driver;
        }

        protected readonly string FolderName = "Sent";

        public By NoSentMessagesLocator { get; set; } = By.XPath("td[text()='No sent messages! ']");
        public IWebElement NoSentMessages => webDriver.JsGetElement(NoSentMessagesLocator).element;

        public By SentMailsLocator => By.XPath("//div[text()='To: ']/ancestor::tr");
        public List<IWebElement> SentMails => webDriver.GetElements(SentMailsLocator);

        public By GetSentMailsBySubjectLocator(string subjectOrBody) => By.XPath($"//span[text()='{subjectOrBody}']");
        public List<IWebElement> GetSentMailsBySubject(string subjectObBody) => webDriver.GetElements(GetSentMailsBySubjectLocator(subjectObBody));
        public IWebElement GetSentMailBySubject(string subjectObBody) => webDriver.GetElement(GetSentMailsBySubjectLocator(subjectObBody));
    }
}
