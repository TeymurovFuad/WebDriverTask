using OpenQA.Selenium;
using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public class Sent : MainPage, IMailFolder
    {
        public string _folderSpecificIdendifierForRetreivingMails { get; private set; } = "div[text()='To: ']";
        public string _folderSpecificIdendifierIfNoMailExists { get; set; } = "td[text()='No sent messages! ']";
        public List<IWebElement> _sentMails { get; private set; }

        public List<IWebElement> GetDraftMails()
        {
            string pathToMails = _mainPageElements.GetXPathToTableContainingMails(_folderSpecificIdendifierForRetreivingMails);
            string emptyFolder = _mainPageElements.GetXPathToTableContainingMails(_folderSpecificIdendifierIfNoMailExists);
            if (isMailboxEmpty(By.XPath(emptyFolder)) && isElementDisplayed(By.XPath(pathToMails)))
            {
                _sentMails = Driver.GetDriver().FindElements(By.XPath(pathToMails)).ToList();
            }
            return _sentMails;
        }

        public IWebElement? GetMailFromTable(string byBody)
        {
            GetDraftMails();
            string pathToSpecificMail = $"//tr//div/span[text()='{byBody}']//ancestor::tr";

            foreach (IWebElement sentMail in _sentMails)
            {
                if (isElementDisplayed(By.XPath(pathToSpecificMail), sentMail))
                {
                    return sentMail;
                }
            }
            return null;
        }

        public void Open()
        {
            IWebElement draftsFolder = _mainPageElements.SentFolder;
            try
            {
                draftsFolder.Click();
            }
            catch (Exception e) when (e is ElementNotVisibleException || e is ElementNotInteractableException)
            {
                DriverManager.WaitUntilElementIsInteractable(draftsFolder);
                draftsFolder.Click();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
