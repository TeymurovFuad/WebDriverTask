using OpenQA.Selenium;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Pages.Gmail.Dialogs.Message;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public class SentFolder : MessageDialog, IMailFolder
    {
        public string FolderSpecificIdendifierIfNoMailExists { get; set; } = "td[text()='No sent messages! ']";
        public string FolderName { get; private set; }
        public string PathToMails = "//div[text()='To: ']/ancestor::tr";
        private string _pathToSpecificMail = "//span[text()='{0}']";

        public List<IWebElement> GetMails()
        {
            WaitUntilElementIsInteractable(GetDriver().FindElement(By.XPath(PathToMails)));
            List<IWebElement> sentMails = GetDriver().FindElements(By.XPath(PathToMails)).ToList();
            return sentMails;
        }

        public IWebElement? GetMailFromTable(string byBodyOrSubject)
        {
            GetMails();
            string path = StringHelper.FormatString(_pathToSpecificMail, byBodyOrSubject)!;
            foreach (IWebElement sentMail in GetMails())
            {
                if (isElementDisplayed(By.XPath(path), sentMail))
                {
                    return sentMail;
                }
            }
            return null;
        }

        public void Open()
        {
            IWebElement sentFolder = mainPageElements.SentFolder;
            SetFolderName(sentFolder);  
            try
            {
                sentFolder.Click();
            }
            catch (Exception e) when (e is ElementNotVisibleException || e is ElementNotInteractableException)
            {
                WaitUntilElementIsInteractable(sentFolder);
                sentFolder.Click();
            }
            catch (Exception)
            {
                throw;
            }
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
            return GetPageTitle().Contains(FolderName, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
