using OpenQA.Selenium;

namespace GmailTest.Pages.Gmail.ContextMenu.Mail
{
    public class MailContextMenu : MailContextMenuElements
    {
        readonly IWebDriver webDriver;
        public MailContextMenu(IWebDriver driver) : base(driver) => webDriver = driver;

        public void ClickDelete()
        {
            DeleteItem.Click();
        }

        public void ClickArchive()
        {
            ArchiveItem.Click();
        }
    }
}
