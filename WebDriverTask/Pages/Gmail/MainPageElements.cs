using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages.Gmail
{
    public class MainPageElements: BaseElements
    {
        public const string FoldersButtonContainerXPath = "//div[h2[text()='Labels'] and //a[text()='Inbox']][1]";
        public static IWebElement FoldersButtonContainer => GetDriver().FindElements(By.XPath(FoldersButtonContainerXPath)).First();

        public const string ComposeButtonXPath = "//div[text()='Compose']";
        public static IWebElement ComposeButton => GetDriver().FindElements(By.XPath(ComposeButtonXPath)).First();

        public const string InboxFolderXPath = "//div[@data-tooltip='Inbox']";
        public static IWebElement InboxFolder => GetDriver().FindElements(By.XPath(InboxFolderXPath)).First();

        public const string DraftsFolderXPath = "//div[@data-tooltip='Drafts']";
        public static IWebElement DraftsFolder => GetDriver().FindElements(By.XPath(DraftsFolderXPath)).First();

        public const string SentFolderXPath = "//div[@data-tooltip='Sent']";
        public static IWebElement SentFolder => GetDriver().FindElements(By.XPath(SentFolderXPath)).First();

        private static string _pathToMailContainingTable = "//table[tbody[position()=1]//{0}]";
        private const string _pathToSpecificMail = "/span[text()='{0}']//ancestor::tr";

        public static IWebElement GetTableContainingMails(string folderSpecificIdentifier)
        {
            IWebElement tableOfMails = Driver.GetDriver().FindElement(By.XPath($"//table[tbody[position()=1]//{folderSpecificIdentifier}]"));
            return tableOfMails;
        }

        public static string GetXPathToTableContainingMails(string folderSpecificIdentifier)
        {
            return StringHelper.FormatString(_pathToMailContainingTable, folderSpecificIdentifier)!;
        }

        public static string PathToSpecificMail(string subjectOrBody)
        {
            return StringHelper.FormatString(_pathToSpecificMail, subjectOrBody);
        }

        public static IWebElement SpecificMailFromTable(string subjectOrBody)
        {
            string pathToMail = PathToSpecificMail(subjectOrBody);
            IWebElement mail = Driver.GetDriver().FindElement(By.XPath(pathToMail));
            DriverManager.WaitUntilElementIsInteractable(mail);
            return mail;
        }
    }
}
