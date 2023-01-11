using NUnit.Framework;
using WebDriverTask.Core.Browser;
using GmailTest.Pages.Gmail;
using WebDriverTask.Core.Helpers;
using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using OpenQA.Selenium.Chrome;
using WebDriverTask.Common.TestConfig;
using WebDriverTask.Business;
using GmailTest.Business;

namespace GmailTest.Tests
{
    //[TestFixtureSource(typeof(TestClassDataProvider), "TestCases")]
    //[Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class GmailTestIndependentCases : Hooks
    {
        protected MainPage mainPage;
        private User _user;
        private Mail _mail;
        private Page _page;

        public GmailTestIndependentCases() : base()
        {
            driverOptions = new ChromeOptions();
            _user = new(email: "qy54313@gmail.com", password: "Aa123456____");
            _mail = new(receiver: "someFakeMail@noSuchAddress.pl", subject: StringHelper.GenerateUUID(), body: "SomeTestBody");
            _page = new(title: "Gmail", language: "English", url: "https://mail.google.com/");
            StopOnFail = false;
            isChained= false;
        }

        [SetUp]
        protected void TestSetup()
        {
            driverManager.BuildDriver(BrowserType.Chrome, driverOptions);
            webDriver = driverManager.GetWebDriver();
            mainPage = new MainPage(webDriver);
            webDriver.GoToUrl(_page.Url);
        }

        [Test]
        public void OpenBrowser()
        {
            webDriver.WaitPageToLoad();
            bool pageDisplayed = webDriver.Title.Contains(_page.Title, StringComparison.CurrentCultureIgnoreCase);
            Assert.IsTrue(pageDisplayed);
        }

        [Test]
        public void ChangePageLanguageToEnglishAndVerifyItChanged()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(_page.Language);
            string actualLanguage = mainPage.loginPage.GetValueOfCurrentSelectedLanguage();
            Assert.That(actualLanguage.Contains(_page.Language, StringComparison.CurrentCultureIgnoreCase), Is.True);
        }

        [Test]
        public void FillUsernameAndPasswordAndLogin()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(_page.Language);
            mainPage.loginPage.Login(_user.Email, _user.Password);
            Assert.IsTrue(mainPage.isTitleDisplayed("inbox"));
        }

        [Test]
        public void OpenDialogToComposeNewMail()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(_page.Language);
            mainPage.loginPage.Login(_user.Email, _user.Password);
            mainPage.ComposeNewMail();
            IWebElement messageDialog = mainPage.messageDialog.GetMailDialog();
            Assert.IsTrue(messageDialog.isElementDisplayed());
        }

        [Test]
        public void FillFieldsInMessageDialogAndCloseDialog()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(_page.Language);
            mainPage.loginPage.Login(_user.Email, _user.Password);
            mainPage.ComposeNewMail();
            mainPage.messageDialog.FillMailData(receiver: _mail.Receiver, subject: _mail.Subject, body: _mail.Body);
            mainPage.messageDialog.CloseMailDialog(subject: _mail.Subject);
            Assert.IsTrue(mainPage.messageDialog.GetMailDialog(subject: _mail.Subject).Displayed);
        }

        [Test]
        public void CreateMailVerifyCreatedMailExistsInDrafts()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(_page.Language);
            mainPage.loginPage.Login(_user.Email, _user.Password);
            mainPage.ComposeNewMail();
            mainPage.messageDialog.FillMailData(receiver: _mail.Receiver, subject: _mail.Subject, body: _mail.Body);
            mainPage.messageDialog.CloseMailDialog(subject: _mail.Subject);
            mainPage.GoToDrafts();
            bool isMailExists = webDriver.isElementDisplayed(mainPage.Mail(_mail.Subject));
            Assert.IsTrue(isMailExists);
        }

        [Test]
        public void SendMailFromDraftAndVerifyMailDissapearedFromDraftFolder()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(_page.Language);
            mainPage.loginPage.Login(_user.Email, _user.Password);
            mainPage.ComposeNewMail();
            mainPage.messageDialog.FillMailData(receiver: _mail.Receiver, subject: _mail.Subject, body: _mail.Body);
            mainPage.messageDialog.CloseMailDialog(subject: _mail.Subject);
            mainPage.GoToDrafts();
            mainPage.OpenExistingMail(_mail.Subject);
            mainPage.messageDialog.SendButton.Click();
            Assert.IsFalse(mainPage.Mail(_mail.Subject).isElementDisplayed());
        }

        [Test]
        public void GoToSentMailsFolderAndVerifyThatMailIsThere()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(_page.Language);
            mainPage.loginPage.Login(_user.Email, _user.Password);
            mainPage.ComposeNewMail();
            mainPage.messageDialog.FillMailData(receiver: _mail.Receiver, subject: _mail.Subject, body: _mail.Body);
            mainPage.messageDialog.CloseMailDialog(subject: _mail.Subject);
            mainPage.GoToDrafts();
            mainPage.OpenExistingMail(_mail.Subject);
            mainPage.messageDialog.SendButton.Click();
            mainPage.GoToSent();
            IWebElement? mail = mainPage.sentFolder.FindSentMailBySubjectOrBody(_mail.Subject);
            Assert.NotNull(mail);
        }

        [Test]
        public void DeleteMailFromSentUsingActionsAndVerifyMailtDeleted()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(_page.Language);
            mainPage.loginPage.Login(_user.Email, _user.Password);
            mainPage.ComposeNewMail();
            mainPage.messageDialog.FillMailData(receiver: _mail.Receiver, subject: _mail.Subject, body: _mail.Body);
            mainPage.messageDialog.CloseMailDialog(subject: _mail.Subject);
            webDriver.WaintUntilUrlChanged(() => mainPage.GoToDrafts());
            mainPage.OpenExistingMail(_mail.Subject);
            mainPage.messageDialog.SendButton.Click();
            webDriver.WaintUntilUrlChanged(() => mainPage.GoToSent());
            mainPage.ToggleMore();
            IWebElement mail = mainPage.sentFolder.FindSentMailBySubjectOrBody(_mail.Subject)!;
            IWebElement trash = mainPage.TrashFolder;
            webDriver.CreateActions().DragAndDrop(source: mail, target: trash).Perform();
            Assert.IsFalse(webDriver.isElementDisplayed(mainPage.Mail(_mail.Subject)));
        }

        [Test]
        public void SignOutAndVerifyUserSignedOutSuccessfully()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(_page.Language);
            mainPage.loginPage.Login(_user.Email, _user.Password);
            mainPage.accoutDialog.OpenAccountDialog(_user.Email);
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