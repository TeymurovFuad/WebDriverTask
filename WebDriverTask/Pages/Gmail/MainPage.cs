using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Pages.Gmail.Dialogs.Account;
using WebDriverTask.Pages.Gmail.Dialogs.Message;
using WebDriverTask.Pages.Gmail.Folders;
using WebDriverTask.Pages.Gmail.Login;
using WebDriverTask.Pages.Gmail.Logout;

namespace WebDriverTask.Pages.Gmail
{
    public class MainPage: MainPageElements
    {
        public IWebDriver webDriver { get; private set; }
        public readonly DraftsFolder draftsFolder;
        public readonly SentFolder sentFolder;
        public readonly MessageDialog messageDialog;
        public readonly AccoutDialog accoutDialog;
        public readonly LoginPage loginPage;
        public readonly LogoutPage logoutPage;

        public MainPage(IWebDriver driver) : base(driver)
        {
            this.webDriver = driver;
            sentFolder = new SentFolder(driver);
            messageDialog = new MessageDialog(driver);
            accoutDialog = new AccoutDialog(driver);
            loginPage = new LoginPage(driver);
            logoutPage = new LogoutPage(driver);
            draftsFolder = new DraftsFolder(driver);
        }

        public void ComposeNewMail()
        {
            messageDialog.CloseAllMailDialogs();
            ComposeButton.Click();
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
            DraftsFolder.Click();
        }

        public void GoToSent()
        {
            SentFolder.Click();
        }
    }
}
