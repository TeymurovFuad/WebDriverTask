using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Pages.Gmail.Dialogs.Message;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public class SentFolder : MessageDialog
    {
        public string FolderSpecificIdendifierIfNoMailExists { get; set; } = "td[text()='No sent messages! ']";
        public string FolderName { get; private set; }
        public string pathToMails = "//div[text()='To: ']/ancestor::tr";
        private string _pathToSpecificMail = "//span[text()='{0}']";

        public List<IWebElement> GetMails()
        {
            DriverInstance().isElementDisplayed(By.XPath(pathToMails));
            List<IWebElement> sentMails = DriverInstance().FindElements(By.XPath(pathToMails)).ToList();
            return sentMails;
        }

        public IWebElement? GetMailFromTable(string byBodyOrSubject)
        {
            GetMails();
            string path = StringHelper.FormatString(_pathToSpecificMail, byBodyOrSubject)!;
            foreach (IWebElement sentMail in GetMails())
            {
                if (sentMail.isContainsChild(By.XPath(path)))
                {
                    return sentMail;
                }
            }
            return null;
        }

        public bool isMailBoxEmpty()
        {
            return DriverInstance().isElementDisplayed(By.XPath(FolderSpecificIdendifierIfNoMailExists));
        }

        private void SetFolderName(IWebElement element)
        {
            FolderName = element.FindElement(By.XPath("//a")).Text;
        }

        public bool VerifyPageOpened()
        {
            return DriverInstance().Title.Contains(FolderName, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
