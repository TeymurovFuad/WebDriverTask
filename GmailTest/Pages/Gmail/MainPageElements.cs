using OpenQA.Selenium;
using WebDriverTask.Common.Pages;
using WebDriverTask.Core.Extensions;

namespace GmailTest.Pages.Gmail
{
    public class MainPageElements: BasePage
    {
        IWebDriver webDriver { get; set; }
        
        public MainPageElements(IWebDriver driver): base(driver)
        {
            webDriver = driver;
        }

        public readonly By FoldersButtonContainerLocator = By.XPath("//div[h2[text()='Labels'] and //a[text()='Inbox']][1]");
        public IWebElement FoldersButtonContainer => webDriver.GetElement(FoldersButtonContainerLocator);

        public readonly By ComposeButtonLocator = By.XPath("//div[text()='Compose']");
        public IWebElement ComposeButton => webDriver.GetElement(ComposeButtonLocator);

        public readonly By InboxFolderLocator = By.XPath("//div[@data-tooltip='Inbox']");
        public IWebElement InboxFolder => webDriver.GetElement(InboxFolderLocator);

        public readonly By DraftsFolderLocator = By.XPath("//div[@data-tooltip='Drafts']");
        public IWebElement DraftsFolder => webDriver.GetElement(DraftsFolderLocator);

        public readonly By SentFolderLocator = By.XPath("//div[@data-tooltip='Sent']");
        public IWebElement SentFolder => webDriver.GetElement(SentFolderLocator);

        public readonly By TrashFolderLocator = By.XPath("//div[@data-tooltip='Trash']");
        public IWebElement TrashFolder => webDriver.GetElement(TrashFolderLocator);

        public readonly By MoreButtonLocator = By.XPath("//span[text()='More']");
        public IWebElement MoreButton => webDriver.GetElement(MoreButtonLocator);

        public readonly By LessButtonLocator = By.XPath("//span[text()='Less']");
        public IWebElement LessButton => webDriver.GetElement(LessButtonLocator);

        public By MailLocator(string subjectOrBody) => By.XPath($"//span[text()='{subjectOrBody}' and parent::span]");
        public IWebElement Mail(string subjectOrBody) => webDriver.JsGetElement(MailLocator(subjectOrBody));

        public By GetTableContainingMailsLocator(string folderSpecificIdentifier) => By.XPath($"//table[tbody[position()=1]//{folderSpecificIdentifier}]");
        public IWebElement GetTableContainingMails(string folderSpecificIdentifier) => webDriver.GetElement(GetTableContainingMailsLocator(folderSpecificIdentifier));
    }
}
