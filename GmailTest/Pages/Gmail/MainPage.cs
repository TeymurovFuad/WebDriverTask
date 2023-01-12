using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using GmailTest.Pages.Gmail.ContextMenu.Mail;
using GmailTest.Pages.Gmail.Dialogs.Account;
using GmailTest.Pages.Gmail.Dialogs.Message;
using GmailTest.Pages.Gmail.Folders.Drafts;
using GmailTest.Pages.Gmail.Folders.Sent;
using GmailTest.Pages.Gmail.Login;
using GmailTest.Pages.Gmail.Logout;
using WebDriverTask.Common.Pages;

namespace GmailTest.Pages.Gmail
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
            webDriver.WaitAndReturnUntilElementIsInteractable(MoreButton)?.Click();
        }

        public void ClickLess()
        {
            webDriver.WaitAndReturnUntilElementIsInteractable(LessButton)?.Click();
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
            ComposeButton.Click();
            webDriver.WaitUntilElementIsInteractable(ComposeButtonLocator);
        }

        public void ComposeAndFillMail(string receiver, string subject, string body)
        {
            messageDialog.CloseAllMailDialogs();
            ComposeButton.Click();
            messageDialog.FillMailData(receiver: receiver, subject: subject, body: body);
        }

        public void OpenFolder(IWebElement folder)
        {
            ClickElement(folder);
        }

        public void OpenExistingMail(string bySubjectOrBody)
        {
            Mail(bySubjectOrBody).JsClick(webDriver);
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
            webDriver.WaitUntilElementDisplayed(logoutPage.ChooseAnAccoutLabelLocator);
        }

        public void GoToDrafts()
        {
            webDriver.WaitUntilElementDisplayed(DraftsFolderLocator);
            webDriver.WaintUntilUrlChanged(() => DraftsFolder.Click());
        }

        public void GoToSent()
        {
            webDriver.WaitUntilElementDisplayed(SentFolderLocator);
            webDriver.WaintUntilUrlChanged(() => SentFolder.Click());
        }

        public void GoToTrash()
        {
            webDriver.WaitUntilElementDisplayed(TrashFolderLocator);
            webDriver.WaintUntilUrlChanged(() => TrashFolder.Click());
        }
    }
}
