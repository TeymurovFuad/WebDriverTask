using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.Helpers;

namespace WebDriverTask.Pages.Gmail
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

        private By _pathToMailContainingTable = By.XPath("//table[tbody[position()=1]//{0}]");
        private readonly By _pathToSpecificMail = By.XPath("/span[text()='{0}']//ancestor::tr");

        public IWebElement GetTableContainingMails(string folderSpecificIdentifier)
        {
            IWebElement tableOfMails = webDriver.GetElement(By.XPath($"//table[tbody[position()=1]//{folderSpecificIdentifier}]"));
            return tableOfMails;
        }

        public string GetXPathToTableContainingMails(string folderSpecificIdentifier)
        {
            return StringHelper.FormatString(_pathToMailContainingTable.GetLocatorValue(), folderSpecificIdentifier)!;
        }

        public string PathToSpecificMail(string subjectOrBody)
        {
            return StringHelper.FormatString(_pathToSpecificMail.GetLocatorType(), subjectOrBody);
        }

        public IWebElement SpecificMailFromTable(string subjectOrBody)
        {
            string pathToMail = PathToSpecificMail(subjectOrBody);
            IWebElement mail = webDriver.GetElement(By.XPath(pathToMail));
            webDriver.WaitUntilElementIsInteractable(mail);
            return mail;
        }
    }
}
