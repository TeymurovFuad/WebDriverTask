using OpenQA.Selenium;
using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public class Drafts: MainPage, IMailFolder
    {
        public string _folderSpecificIdendifierForRetreivingMails { get; private set; } = "span[text()='Draft]";
        public string _folderSpecificIdendifierIfNoMailExists { get; private set; } = "td[text()=\"You don't have any saved drafts.\"]";
        public List<IWebElement> _draftMails { get; private set; }

        public void Open()
        {
            IWebElement draftsFolder = _mainPageElements.DraftsFolder;
            try
            {
                draftsFolder.Click();
            }
            catch (Exception e)when(e is ElementNotVisibleException || e is ElementNotInteractableException)
            {
                DriverManager.WaitUntilElementIsInteractable(draftsFolder);
                draftsFolder.Click();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<IWebElement> GetDraftMails()
        {
            string pathToMails = _mainPageElements.GetXPathToTableContainingMails(_folderSpecificIdendifierForRetreivingMails);
            string emptyFolder = _mainPageElements.GetXPathToTableContainingMails(_folderSpecificIdendifierIfNoMailExists);
            if (isMailboxEmpty(By.XPath(emptyFolder)) && isElementDisplayed(By.XPath(pathToMails)))
            {
                _draftMails = Driver.GetDriver().FindElements(By.XPath(pathToMails)).ToList();
            }
            return _draftMails;
        }

        public IWebElement? GetMailFromTable(string? bySubject, string? byBody)
        {
            GetDraftMails();
            if (bySubject == null && byBody == null)
            {
                throw new ArgumentNullException("Either the subject or the body must be provided");
            }
            string pathToSpecificMail = $"//tr//div/span[text()='{bySubject ?? byBody}']//ancestor::tr";

            foreach(IWebElement draftMail in _draftMails)
            {
                if(isElementDisplayed(By.XPath(pathToSpecificMail), draftMail))
                {
                    return draftMail;
                }
            }
            return null;
        }
    }
}
