using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Pages.Gmail.Dialogs.Account;
using WebDriverTask.Pages.Gmail.Dialogs.Message;
using WebDriverTask.Pages.Gmail.Folders;
using WebDriverTask.Pages.Gmail.Login;
using WebDriverTask.Pages.Gmail.Logout;

namespace WebDriverTask.Pages.Gmail
{
    public class MainPage: BasePage
    {
        public IWebDriver webDriver { get; private set; }
        public readonly MainPageElements mainPageElements;
        public readonly DraftsFolder draftsFolder;
        public readonly SentFolder sentFolder;
        public readonly MessageDialog messageDialog;
        public readonly AccoutDialog accoutDialog;
        public readonly LoginPage loginPage;
        public readonly LogoutPage logoutPage;

        public MainPage(IWebDriver webDriver) : base()
        {
            this.webDriver = webDriver;
            mainPageElements = new MainPageElements();
            sentFolder = new SentFolder();
            messageDialog = new MessageDialog();
            accoutDialog = new AccoutDialog();
            loginPage = new LoginPage();
            logoutPage = new LogoutPage();
            draftsFolder = new DraftsFolder();
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
            return webDriver.isElementDisplayed(locator);
        }

        public void GoToDrafts()
        {
            mainPageElements.DraftsFolder.Click();
        }

        public void GoToSent()
        {
            mainPageElements.SentFolder.Click();
        }
    }
}
