using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Pages.Gmail.Dialogs.Message;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public class SentFolder : MessageDialog
    {
        IWebDriver webDriver { get; set; }
        public SentFolder(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        public By FolderSpecificIdendifierIfNoMailExists { get; set; } = By.XPath("td[text()='No sent messages! ']");
        public string FolderName { get; private set; }
        public By pathToMails = By.XPath("//div[text()='To: ']/ancestor::tr");
        private By _pathToSpecificMail = By.XPath("//span[text()='{0}']");

        public List<IWebElement> GetMails()
        {
            webDriver.isElementDisplayed(pathToMails);
            List<IWebElement> sentMails = webDriver.FindElements(pathToMails).ToList();
            return sentMails;
        }

        public IWebElement? GetMailFromTable(string byBodyOrSubject)
        {
            GetMails();
            string path = StringHelper.FormatString(_pathToSpecificMail.GetLocatorValue(), byBodyOrSubject)!;
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
            return webDriver.isElementDisplayed(FolderSpecificIdendifierIfNoMailExists);
        }

        private void SetFolderName(IWebElement element)
        {
            FolderName = element.FindElement(By.XPath("//a")).Text;
        }

        public bool VerifyPageOpened()
        {
            return webDriver.Title.Contains(FolderName, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
