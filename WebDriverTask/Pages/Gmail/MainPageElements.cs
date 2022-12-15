using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Security.Cryptography.X509Certificates;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Pages.Gmail
{
    public static class MainPageElements
    {
        [FindsBy(How = How.XPath, Using = "//div[h2[text()='Labels'] and //a[text()='Inbox']][1]")]
        public static IWebElement FoldersButtonContainer { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Compose']")]
        public static IWebElement ComposeButton { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Inbox']")]
        public static IWebElement InboxFolder { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Drafts']")]
        public static IWebElement DraftsFolder { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Sent']")]
        public static IWebElement SentFolder { get; private set; }

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
