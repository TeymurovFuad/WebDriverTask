using OpenQA.Selenium;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public class InboxFolder : MainPage, IMailFolder
    {
        public string PathToDraftMails => throw new NotImplementedException();

        public string FolderSpecificIdendifierIfNoMailExists => throw new NotImplementedException();

        public List<IWebElement> GetMails()
        {
            throw new NotImplementedException();
        }

        public IWebElement? GetMailFromTable(string? bySubject, string? byBody)
        {
            throw new NotImplementedException();
        }

        public static void Open()
        {
            throw new NotImplementedException();
        }
    }
}
