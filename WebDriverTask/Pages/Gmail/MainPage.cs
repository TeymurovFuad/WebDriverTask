using OpenQA.Selenium;
using WebDriverTask.Pages.Gmail.Folders;
using WebDriverTask.Pages.Gmail.MailDialog;

namespace WebDriverTask.Pages.Gmail
{
    public class MainPage: BasePage
    {
        public MainPage() : base() { }

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
            DraftsFolder.Open();
        }

        public static void GoToSent()
        {
            SentFolder.Open(); 
        }

        public static void GoToInbox()
        {
            InboxFolder.Open();
        }
    }
}
