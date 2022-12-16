using OpenQA.Selenium;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public class Drafts : MainPage, IMailFolder
    {
        public static string PathToDraftMails { get; private set; } = "//span[text()='Draft']/ancestor::tr";
        public static string FolderSpecificIdendifierIfNoMailExists { get; private set; } = "td[text()=\"You don't have any saved drafts.\"]";
        private static string _pathToSpecificDraftMails = "//span[text()='{0}']";
        public static List<IWebElement> DraftMails { get; private set; }
        public static string FolderName { get; private set; }

        public static void Open()
        {
            IWebElement draftsFolder = MainPageElements.DraftsFolder;
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

        public static List<IWebElement> GetMails()
        {
            DraftMails = GetDriver().FindElements(By.XPath(PathToDraftMails)).ToList();
            return DraftMails;
        }

        public static IWebElement? GetMailFromTable(string bySubjectOrBody)
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

        public static bool isMailBoxEmpty()
        {
            return isElementDisplayed(By.XPath(FolderSpecificIdendifierIfNoMailExists));
        }

        private static void SetFolderName(IWebElement element)
        {
            FolderName = element.FindElement(By.XPath("//a")).Text;
        }

        public static bool VerifyPageOpened()
        {
            return GetPageTitle().Contains(FolderName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
