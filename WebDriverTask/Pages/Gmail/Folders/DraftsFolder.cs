using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Pages.Gmail.Dialogs.Message;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public class DraftsFolder : MessageDialog
    {
        IWebDriver webDriver { get; set; }
        public DraftsFolder(IWebDriver driver): base(driver)
        {
            webDriver = driver;
        }

        public string PathToDraftMails { get; private set; } = "//span[text()='Draft']/ancestor::tr";
        public string FolderSpecificIdendifierIfNoMailExists { get; private set; } = "td[text()=\"You don't have any saved drafts.\"]";
        private string _pathToSpecificDraftMails => "//span[text()='{0}']";
        public List<IWebElement> DraftMails { get; private set; }
        public string FolderName { get; private set; }

        public List<IWebElement> GetMails()
        {
            DraftMails = webDriver.FindElements(By.XPath(PathToDraftMails)).ToList();
            return DraftMails;
        }

        public IWebElement? GetMailFromTable(string bySubjectOrBody)
        {
            GetMails();
            string path = StringHelper.FormatString(_pathToSpecificDraftMails, bySubjectOrBody)!;
            foreach (IWebElement draftMail in DraftMails)
            {
                if(draftMail.isContainsChild(By.XPath(path)))
                {
                    return draftMail;
                }
            }
            return null;
        }

        public bool isMailBoxEmpty()
        {
            return webDriver.isElementDisplayed(By.XPath(FolderSpecificIdendifierIfNoMailExists));
        }

        private void SetFolderName(IWebElement element)
        {
            FolderName = element.FindElement(By.XPath("//a")).Text;
        }

        public bool VerifyPageOpened()
        {
            return webDriver.Title.Contains(FolderName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
