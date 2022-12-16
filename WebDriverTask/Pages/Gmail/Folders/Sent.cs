using OpenQA.Selenium;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public class Sent : MainPage, IMailFolder
    {
        public static string FolderSpecificIdendifierIfNoMailExists { get; set; } = "td[text()='No sent messages! ']";
        public static string FolderName { get; private set; }
        public static string PathToMails = "//div[text()='To: ']/ancestor::tr";
        private static string _pathToSpecificMail = "//span[text()='{byBodyOrSubject}']";

        public static List<IWebElement> GetMails()
        {
            WaitUntilElementIsInteractable(GetDriver().FindElement(By.XPath(PathToMails)));
            List<IWebElement> sentMails = GetDriver().FindElements(By.XPath(PathToMails)).ToList();
            return sentMails;
        }

        public static IWebElement? GetMailFromTable(string byBodyOrSubject)
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

        public static void Open()
        {
            IWebElement sentFolder = MainPageElements.SentFolder;
            SetFolderName(sentFolder);
            try
            {
                sentFolder.Click();
            }
            catch (Exception e) when (e is ElementNotVisibleException || e is ElementNotInteractableException)
            {
                DriverManager.WaitUntilElementIsInteractable(sentFolder);
                sentFolder.Click();
            }
            catch (Exception)
            {
                throw;
            }
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
