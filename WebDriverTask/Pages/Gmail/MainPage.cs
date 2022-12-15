using OpenQA.Selenium;
using WebDriverTask.Pages.Gmail.Folders;
using WebDriverTask.Pages.Gmail.MailDialog;

namespace WebDriverTask.Pages.Gmail
{
    public class MainPage: BasePage
    {
        private Drafts _drafts;
        private Inbox _inbox;
        private Sent _sent;

        public MainPage() : base()
        {
            _drafts = new Drafts();
            _inbox = new Inbox();
            _sent = new Sent();
        }

        public static void ComposeNewMail()
        {
            MessageDialog.CloseAllMailDialogs();
            MainPageElements.ComposeButton.Click();
        }

        public void OpenFolder(IWebElement folder)
        {
            ClickElement(folder);
        }

        protected bool isMailboxEmpty(By locator)
        {
            return isElementDisplayed(locator);
        }

        public static void GoToDrafts()
        {
            Drafts.Open();
        }

        public static void GoToSent()
        {
            Sent.Open(); 
        }

        public static void GoToInbox()
        {
            Inbox.Open();
        }
    }
}
