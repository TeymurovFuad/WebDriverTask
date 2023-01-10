using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Pages.Gmail.ContextMenu.Mail;
using WebDriverTask.Pages.Gmail.Dialogs.Account;
using WebDriverTask.Pages.Gmail.Dialogs.Message;
using WebDriverTask.Pages.Gmail.Folders.Drafts;
using WebDriverTask.Pages.Gmail.Folders.Sent;
using WebDriverTask.Pages.Gmail.Login;
using WebDriverTask.Pages.Gmail.Logout;
using WebDriverTask.Utils.Extensions;

namespace WebDriverTask.Pages.Gmail
{
    public class MainPage: MainPageElements, IPage
    {
        IWebDriver webDriver { get; set; }
        public readonly DraftsFolder draftsFolder;
        public readonly SentFolder sentFolder;
        public readonly MessageDialog messageDialog;
        public readonly AccountDialog accoutDialog;
        public readonly LoginPage loginPage;
        public readonly LogoutPage logoutPage;
        public readonly MailContextMenu mailContextMenu;

        public MainPage(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
            sentFolder = new SentFolder(driver);
            messageDialog = new MessageDialog(driver);
            accoutDialog = new AccountDialog(driver);
            loginPage = new LoginPage(driver);
            logoutPage = new LogoutPage(driver);
            draftsFolder = new DraftsFolder(driver);
            mailContextMenu = new MailContextMenu(driver);
        }

        public void ClickMore()
        {
            webDriver.WaitUntilElementIsInteractable(MoreButton)?.Click();
        }

        public void ClickLess()
        {
            webDriver.WaitUntilElementIsInteractable(LessButton)?.Click();
        }

        public void ToggleMore()
        {
            try
            {
                ClickMore();
            }
            catch(ElementNotInteractableException)
            {
                ClickLess();
            }
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

        public void LogOut(string email)
        {
            accoutDialog.OpenAccountDialog(email);
            accoutDialog.SwitchToAccountFrame();
            accoutDialog.ClickSignOut();
            AlertAccept();
            webDriver.WaitUntilElementDisplayed(logoutPage.ChooseAnAccoutLabel);
        }

        public void GoToDrafts()
        {
            webDriver.WaitUntilElementDisplayed(DraftsFolder);
            DraftsFolder.Click();
        }

        public void GoToSent()
        {
            webDriver.WaitUntilElementDisplayed(SentFolder);
            SentFolder.Click();
        }

        public void GoToTrash()
        {
            webDriver.WaitUntilElementDisplayed(TrashFolder);
            TrashFolder.Click();
        }
    }
}
