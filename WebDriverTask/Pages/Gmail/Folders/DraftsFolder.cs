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

        public By PathToDraftMails { get; private set; } = By.XPath("//span[text()='Draft']/ancestor::tr");
        public By FolderSpecificIdendifierIfNoMailExists { get; private set; } = By.XPath("td[text()=\"You don't have any saved drafts.\"]");
        private By _pathToSpecificDraftMails => By.XPath("//span[text()='{0}']");
        public List<IWebElement> DraftMails { get; private set; }
        public string FolderName { get; private set; }

        public List<IWebElement> GetMails()
        {
            DraftMails = webDriver.GetElements(PathToDraftMails).ToList();
            return DraftMails;
        }

        public IWebElement? GetMailFromTable(string bySubjectOrBody)
        {
            GetMails();
            string path = StringHelper.FormatString(_pathToSpecificDraftMails.GetLocatorValue(), bySubjectOrBody)!;
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
            return webDriver.isElementDisplayed(FolderSpecificIdendifierIfNoMailExists);
        }

        private void SetFolderName(IWebElement element)
        {
            FolderName = element.GetElement(By.XPath("//a")).Text;
        }

        public bool VerifyPageOpened()
        {
            return webDriver.Title.Contains(FolderName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
