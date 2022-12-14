using OpenQA.Selenium;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public interface IMailFolder
    {
        public string _folderSpecificIdendifierForRetreivingMails { get; }
        public string _folderSpecificIdendifierIfNoMailExists { get; }
        public List<IWebElement> GetDraftMails();
        public virtual IWebElement? GetMailFromTable() { return null; }
        public void Open();
    }
}
