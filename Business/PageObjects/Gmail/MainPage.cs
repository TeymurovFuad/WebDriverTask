using OpenQA.Selenium;
using Core.Extensions;
using Core.Utils.Extensions;
using Core.Common.Pages;
using Business.PageObjects.Gmail.ContextMenu.Mail;
using Business.PageObjects.Gmail.Folders.Drafts;
using Business.PageObjects.Gmail.Folders.Sent;
using Business.PageObjects.Gmail.Login;
using Business.PageObjects.Gmail.Logout;
using Business.PageObjects.Gmail.ContextMenu.Dialogs.Message;
using Business.PageObjects.Gmail.ContextMenu.Dialogs.Account;

namespace Business.PageObjects.Gmail
{
    public class MainPage : MainPageElements, IPage
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
            webDriver.WaitUntilElementIsInteractable(MoreButtonLocator);
            MoreButton.Click();
        }

        public void ClickLess()
        {
            webDriver.WaitUntilElementIsInteractable(LessButtonLocator);
            LessButton.Click();
        }

        public void ToggleMore()
        {
            try
            {
                ClickMore();
            }
            catch (ElementNotInteractableException)
            {
                ClickLess();
            }
        }

        public void ComposeNewMail()
        {
            webDriver.WaitUntilElementIsInteractable(ComposeButtonLocator);
            ComposeButton.Click();
            webDriver.WaitUntilElementDisplayed(messageDialog.NewMailDialogsByHeaderLocator);
        }

        public void ComposeAndFillMail(string receiver, string subject, string body)
        {
            messageDialog.CloseAllMailDialogs();
            ComposeButton.Click();
            messageDialog.FillMailData(receiver: receiver, subject: subject, body: body);
        }

        public void OpenFolder(By folderLocator)
        {
            ClickElement(folderLocator);
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
            webDriver.WaitUntilElementIsInteractable(DraftsFolderLocator);
            webDriver.WaintUntilUrlChanged(() => DraftsFolder.Click());
        }

        public void GoToSent()
        {
            webDriver.WaitUntilElementIsInteractable(SentFolderLocator);
            webDriver.WaintUntilUrlChanged(() => SentFolder.Click());
        }

        public void GoToTrash()
        {
            webDriver.WaitUntilElementIsInteractable(TrashFolderLocator);
            webDriver.WaintUntilUrlChanged(() => TrashFolder.Click());
        }
    }
}
