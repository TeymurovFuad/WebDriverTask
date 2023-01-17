using GmailTest.Pages.Gmail;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverTask.Core.Browser;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Utils.Extensions;
using WebDriverTask.Utils.Helpers;

namespace GmailTest.Tests
{
    //[TestFixtureSource(typeof(TestClassDataProvider), "TestCases")]
    //[Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class GmailTestIndependentCases : Hooks
    {
        protected MainPage mainPage;

        public GmailTestIndependentCases() : base()
        {
            driverOptions = new ChromeOptions();
            user = new(email: "qy54313@gmail.com", password: "Aa123456____");
            mail = new(receiver: "someFakeMail@noSuchAddress.pl", subject: StringHelper.GenerateUUID(), body: "SomeTestBody");
            page = new(title: "Gmail", language: "English", url: "https://mail.google.com/");
            StopOnFail = false;
            isChained = false;
        }

        [SetUp]
        protected void TestSetup()
        {
            driverManager.BuildDriver(BrowserType.Chrome, driverOptions);
            webDriver = driverManager.GetWebDriver();
            mainPage = new MainPage(webDriver);
            webDriver.GoToUrl(page.Url);
        }

        [Test]
        public void OpenBrowser()
        {
            webDriver.WaitPageToLoad();
            bool pageDisplayed = webDriver.Title.Contains(page.Title, StringComparison.CurrentCultureIgnoreCase);
            Assert.IsTrue(pageDisplayed);
        }

        [Test]
        public void ChangePageLanguageToEnglishAndVerifyItChanged()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(page.Language);
            string actualLanguage = mainPage.loginPage.GetValueOfCurrentSelectedLanguage();
            Assert.IsTrue(actualLanguage.Contains(page.Language, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void FillUsernameAndPasswordAndLogin()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(page.Language);
            mainPage.loginPage.Login(user.Email, user.Password);
            Assert.IsTrue(mainPage.isTitleDisplayed("inbox"));
        }

        [Test]
        public void OpenDialogToComposeNewMail()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(page.Language);
            mainPage.loginPage.Login(user.Email, user.Password);
            mainPage.ComposeNewMail();
            bool isDisplayed = webDriver.WaitUntilElementDisplayed(mainPage.messageDialog.NewMailDialog).isDisplayed;
            Assert.IsTrue(isDisplayed);
        }

        [Test]
        public void FillFieldsInMessageDialogAndCloseDialog()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(page.Language);
            mainPage.loginPage.Login(user.Email, user.Password);
            mainPage.ComposeNewMail();
            mainPage.messageDialog.FillMailData(receiver: mail.Receiver, subject: mail.Subject, body: mail.Body);
            mainPage.messageDialog.CloseAllMailDialogs();
            Assert.IsFalse(mainPage.messageDialog.GetMailDialog(mail.Subject).isElementDisplayed());
        }

        [Test]
        public void CreateMailVerifyCreatedMailExistsInDrafts()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(page.Language);
            mainPage.loginPage.Login(user.Email, user.Password);
            mainPage.ComposeNewMail();
            mainPage.messageDialog.FillMailData(receiver: mail.Receiver, subject: mail.Subject, body: mail.Body);
            mainPage.messageDialog.CloseMailDialog(subject: mail.Subject);
            mainPage.GoToDrafts();
            Assert.IsNotNull(mainPage.draftsFolder.GetDraftMailsByValue(mail.Subject));
        }

        [Test]
        public void SendMailFromDraftAndVerifyMailDissapearedFromDraftFolder()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(page.Language);
            mainPage.loginPage.Login(user.Email, user.Password);
            mainPage.ComposeNewMail();
            mainPage.messageDialog.FillMailData(receiver: mail.Receiver, subject: mail.Subject, body: mail.Body);
            mainPage.messageDialog.CloseMailDialog(subject: mail.Subject);
            mainPage.GoToDrafts();
            mainPage.OpenExistingMail(mail.Subject);
            mainPage.messageDialog.SendButton.Click();
            bool isDisplayed = webDriver.isElementDisplayed(mainPage.messageDialog.MailDialogsByHeaderLocator(base.mail.Subject));
            Assert.IsFalse(isDisplayed);
        }

        [Test]
        public void GoToSentMailsFolderAndVerifyThatMailIsThere()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(page.Language);
            mainPage.loginPage.Login(user.Email, user.Password);
            mainPage.ComposeNewMail();
            mainPage.messageDialog.FillMailData(receiver: mail.Receiver, subject: mail.Subject, body: mail.Body);
            mainPage.messageDialog.CloseAllMailDialogs();
            mainPage.GoToDrafts();
            mainPage.draftsFolder.GetDraftMailByValue(mail.Subject).Click();
            mainPage.messageDialog.SendButton.Click();
            mainPage.GoToSent();
            IWebElement? sentMail = mainPage.sentFolder.GetSentMailBySubject(base.mail.Subject);
            Assert.NotNull(sentMail);
        }

        [Test]
        public void DeleteMailFromSentUsingActionsAndVerifyMailtDeleted()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(page.Language);
            mainPage.loginPage.Login(user.Email, user.Password);
            mainPage.ComposeNewMail();
            mainPage.messageDialog.FillMailData(receiver: mail.Receiver, subject: mail.Subject, body: mail.Body);
            mainPage.messageDialog.CloseMailDialog(subject: mail.Subject);
            mainPage.GoToDrafts();
            mainPage.draftsFolder.GetDraftMailByValue(mail.Subject);
            mainPage.messageDialog.SendButton.Click();
            mainPage.GoToSent();
            mainPage.ToggleMore();
            webDriver.CreateActions().ContextClick(mainPage.sentFolder.GetSentMailBySubject(mail.Subject)).Perform();
            webDriver.CreateActions().Click(mainPage.mailContextMenu.DeleteItem).Perform();
            bool isDisplayed = webDriver.isElementDisplayed(mainPage.sentFolder.MailDialogsByHeaderLocator(base.mail.Subject));
            Assert.IsFalse(isDisplayed);
        }

        [Test]
        public void SignOutAndVerifyUserSignedOutSuccessfully()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(page.Language);
            mainPage.loginPage.Login(user.Email, user.Password);
            mainPage.accoutDialog.OpenAccountDialog(user.Email);
            mainPage.accoutDialog.SwitchToAccountFrame();
            mainPage.accoutDialog.ClickSignOut();
            bool loggedOut = webDriver.WaitUntilElementDisplayed(mainPage.logoutPage.ChooseAnAccoutLabel).isDisplayed;
            Assert.IsTrue(loggedOut);
        }

        [TearDown]
        protected void TestTearDown()
        {
            driverManager.QuitDriver();
        }
    }
}