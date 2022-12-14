using OpenQA.Selenium;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public class Inbox : MainPage, IMailFolder
    {
        public string _folderSpecificIdendifierForRetreivingMails => throw new NotImplementedException();

        public string _folderSpecificIdendifierIfNoMailExists => throw new NotImplementedException();

        public List<IWebElement> GetDraftMails()
        {
            throw new NotImplementedException();
        }

        public IWebElement? GetMailFromTable(string? bySubject, string? byBody)
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }
    }
}
