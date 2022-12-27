using OpenQA.Selenium;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Pages.Gmail.Dialogs.Message;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public class DraftsFolder : MessageDialog, IMailFolder
    {
        public string PathToDraftMails { get; private set; } = "//span[text()='Draft']/ancestor::tr";
        public string FolderSpecificIdendifierIfNoMailExists { get; private set; } = "td[text()=\"You don't have any saved drafts.\"]";
        private string _pathToSpecificDraftMails => "//span[text()='{0}']";
        public List<IWebElement> DraftMails { get; private set; }
        public string FolderName { get; private set; }

        public void Open()
        {
            IWebElement draftsFolder = mainPageElements.DraftsFolder;
            SetFolderName(draftsFolder);
            try
            {
                draftsFolder.Click();
            }
            catch (Exception e)when(e is ElementNotVisibleException || e is ElementNotInteractableException)
            {
                WaitUntilElementIsInteractable(draftsFolder);
                draftsFolder.Click();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<IWebElement> GetMails()
        {
            DraftMails = GetDriver().FindElements(By.XPath(PathToDraftMails)).ToList();
            return DraftMails;
        }

        public IWebElement? GetMailFromTable(string bySubjectOrBody)
        {
            GetMails();
            string path = StringHelper.FormatString(_pathToSpecificDraftMails, bySubjectOrBody)!;
            foreach (IWebElement draftMail in DraftMails)
            {
                if(isElementDisplayed(By.XPath(path), draftMail))
                {
                    return draftMail;
                }
            }
            return null;
        }

        public bool isMailBoxEmpty()
        {
            return isElementDisplayed(By.XPath(FolderSpecificIdendifierIfNoMailExists));
        }

        private void SetFolderName(IWebElement element)
        {
            FolderName = element.FindElement(By.XPath("//a")).Text;
        }

        public bool VerifyPageOpened()
        {
            return GetPageTitle().Contains(FolderName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
