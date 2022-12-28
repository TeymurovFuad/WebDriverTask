using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.Helpers;

namespace WebDriverTask.Pages.Gmail
{
    public class MainPageElements: BaseElements
    {
        public readonly string FoldersButtonContainerXPath = "//div[h2[text()='Labels'] and //a[text()='Inbox']][1]";
        public IWebElement FoldersButtonContainer => GetDriver().FindElements(By.XPath(FoldersButtonContainerXPath)).First();

        public readonly string ComposeButtonXPath = "//div[text()='Compose']";
        public IWebElement ComposeButton => GetDriver().FindElements(By.XPath(ComposeButtonXPath)).First();

        public readonly string InboxFolderXPath = "//div[@data-tooltip='Inbox']";
        public IWebElement InboxFolder => GetDriver().FindElements(By.XPath(InboxFolderXPath)).First();

        public readonly string DraftsFolderXPath = "//div[@data-tooltip='Drafts']";
        public IWebElement DraftsFolder => GetDriver().FindElements(By.XPath(DraftsFolderXPath)).First();

        public readonly string SentFolderXPath = "//div[@data-tooltip='Sent']";
        public IWebElement SentFolder => GetDriver().FindElements(By.XPath(SentFolderXPath)).First();

        private string _pathToMailContainingTable = "//table[tbody[position()=1]//{0}]";
        private readonly string _pathToSpecificMail = "/span[text()='{0}']//ancestor::tr";

        public IWebElement GetTableContainingMails(string folderSpecificIdentifier)
        {
            IWebElement tableOfMails = GetDriver().FindElement(By.XPath($"//table[tbody[position()=1]//{folderSpecificIdentifier}]"));
            return tableOfMails;
        }

        public string GetXPathToTableContainingMails(string folderSpecificIdentifier)
        {
            return StringHelper.FormatString(_pathToMailContainingTable, folderSpecificIdentifier)!;
        }

        public string PathToSpecificMail(string subjectOrBody)
        {
            return StringHelper.FormatString(_pathToSpecificMail, subjectOrBody);
        }

        public IWebElement SpecificMailFromTable(string subjectOrBody)
        {
            string pathToMail = PathToSpecificMail(subjectOrBody);
            IWebElement mail = GetDriver().FindElement(By.XPath(pathToMail));
            GetDriver().WaitUntilElementIsInteractable(mail);
            return mail;
        }
    }
}
