using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Pages.Gmail.Dialogs.Message;

namespace WebDriverTask.Pages.Gmail.Folders.Drafts
{
    public class DraftsFolderElements: MessageDialog
    {
        IWebDriver webDriver;
        public DraftsFolderElements(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        protected readonly string FolderName = "Drafts";

        public By NoMailsInDraftLocator => By.XPath("td[text()=\"You don't have any saved drafts.\"]");
        public IWebElement NoMailsInDraft => webDriver.GetElement(NoMailsInDraftLocator);

        public By DraftMailsLocator { get; private set; } = By.XPath("//span[text()='Draft']/ancestor::tr");
        public List<IWebElement> DraftMails => webDriver.GetElements(DraftMailsLocator);

        public By GetDraftMailsByValueLocator(string subjectOrBody) => By.XPath($"//span[text()='{subjectOrBody}']");
        public List<IWebElement> GetDraftMailsByValue(string subjectOrBody) => webDriver.GetElements(GetDraftMailsByValueLocator(subjectOrBody));
        public IWebElement GetDraftMailByValue(string subjectOrBody) => webDriver.JsGetElement(GetDraftMailsByValueLocator(subjectOrBody)).element;
    }
}
