using OpenQA.Selenium;

namespace WebDriverTask.Pages.Gmail.Folders
{
    public interface IMailFolder
    {
        protected virtual string PathToDraftMails { get => throw new NotImplementedException(); }
        protected virtual string FolderSpecificIdendifierIfNoMailExists { get => throw new NotImplementedException(); }
        public virtual List<IWebElement> GetMails() { throw new NotImplementedException(); }
        public virtual IWebElement? GetMailFromTable() { throw new NotImplementedException(); }
        public virtual void Open() { throw new NotImplementedException(); }
        public virtual bool isMailBoxEmpty() { throw new NotImplementedException(); }
        public virtual bool VerifyPageOpened() { throw new NotImplementedException(); }
    }
}
