using OpenQA.Selenium;
using WebDriverTask.Pages.Gmail.Dialogs.Account;
using WebDriverTask.Pages.Gmail.Dialogs.Message;
using WebDriverTask.Pages.Gmail.Folders;
using WebDriverTask.Pages.Gmail.Login;
using WebDriverTask.Pages.Gmail.Logout;

namespace WebDriverTask.Pages.Gmail
{
    public class MainPage: BasePage
    {
        public readonly MainPageElements mainPageElements;
        public readonly DraftsFolder draftsFolder;
        public readonly SentFolder sentFolder;
        public readonly MessageDialog messageDialog;
        public readonly AccoutDialog accoutDialog;
        public readonly LoginPage loginPage;
        public readonly LogoutPage logoutPage;

        public MainPage() : base()
        {
            mainPageElements = new MainPageElements();
            draftsFolder = new DraftsFolder();
            sentFolder = new SentFolder();
            messageDialog = new MessageDialog();
            accoutDialog = new AccoutDialog();
            loginPage = new LoginPage();
            logoutPage = new LogoutPage();
        }

        public void ComposeNewMail()
        {
            messageDialog.CloseAllMailDialogs();
            mainPageElements.ComposeButton.Click();
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
            draftsFolder.Open();
        }

        public void GoToSent()
        {
            sentFolder.Open(); 
        }
    }
}
