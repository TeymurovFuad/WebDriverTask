using OpenQA.Selenium;
using WebDriverTask.Pages.Gmail.Folders;
using WebDriverTask.Pages.Gmail.MailDialog;

namespace WebDriverTask.Pages.Gmail
{
    public class MainPage: BasePage
    {
        public MainPageElements _mainPageElements { get; private set; }
        private Drafts _drafts;
        private Inbox _inbox;
        private Sent _sent;
        private BasePage _basePage;

        public MainPage()
        {
            _mainPageElements = new MainPageElements();
            _drafts = new Drafts();
            _inbox = new Inbox();
            _sent = new Sent();
        }

        public void ComposeNewMail()
        {
            MessageDialog.CloseMailDialog();
            _mainPageElements.ComposeButton.Click();
        }

        public void OpenFolder(IWebElement folder)
        {
            ClickElement(folder);
        }

        protected bool isMailboxEmpty(By locator)
        {
            return isElementDisplayed(locator);
        }

        public void GoToDrafts()
        {
            _drafts.Open();
        }

        public void GoToSent()
        {
            _sent.Open(); 
        }

        public void GoToInbox()
        {
            _inbox.Open();
        }
    }
}
