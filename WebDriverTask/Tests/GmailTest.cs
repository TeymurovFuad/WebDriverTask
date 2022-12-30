using NUnit.Framework;
using WebDriverTask.Tests.TestConfig;
using WebDriverTask.Core.Browser;
using WebDriverTask.Pages.Gmail;
using WebDriverTask.Core.Helpers;
using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Tests
{
    [TestFixture]
    public class GmailTest: Hooks
    {
        private MainPage _mainPage;
        private static string _url = "https://mail.google.com/";

        public GmailTest() : base(browserType: BrowserType.Chrome, url: _url)
        {
            _mainPage = new MainPage(webDriver);
            StopOnFail= true;
        }

        [Test, Order(1)]
        public void OpenBrowser()
        {
            webDriver.WaitPageToLoad();
            Assert.IsTrue(webDriver.Title.Contains("gmail", StringComparison.CurrentCultureIgnoreCase));
        }

        [Test, Order(2)]
        [TestCase("english")]
        public void ChangePageLanguageToEnglishAndVerifyItChanged(string expectedLanguage)
        {
            _mainPage.loginPage.ToggleLanguageChooserDropDown();
            _mainPage.loginPage.ChangeLanguage(expectedLanguage);
            string actualLanguage = _mainPage.loginPage.GetValueOfCurrentSelectedLanguage();
            Assert.That(actualLanguage.Contains(expectedLanguage, StringComparison.CurrentCultureIgnoreCase), Is.True);
        }

        [Test, Order(3)]
        [TestCase("qy54313@gmail.com", "Aa123456____")]
        public void FillUsernameAndPasswordAndLogin(string email, string password)
        {
            _mainPage.loginPage.FillEmail(email);
            _mainPage.loginPage.ClickNext();
            _mainPage.loginPage.FillPassword(password);
            _mainPage.loginPage.ClickNext();
            testData.SetVariable("email", email);
        }

        [Test, Order(4)]
        public void OpenDialogToComposeNewMail()
        {
            _mainPage.ComposeNewMail();
            IWebElement messageDialog = _mainPage.messageDialog.GetMailDialog();
            Assert.IsTrue(messageDialog.isElementDisplayed());
        }

        [Test, Order(5)]
        [TestCase("someFakeMail@noSuchAddress.pl", "", "SomeTestBody ")]
        public void FillFieldsInMessageDialogAndCloseDialog(string someMailAddress, string someSubject, string someBody)
        {
            someSubject += StringHelper.GenerateUUID();
            _mainPage.messageDialog.MailTo(someMailAddress);
            _mainPage.messageDialog.MailSubject(someSubject);
            _mainPage.messageDialog.MailBody(someBody);
            _mainPage.messageDialog.CloseAllMailDialogs();
            Assert.IsTrue(_mainPage.messageDialog.AllMailDialogs().Count == 0)

            testData.SetVariable("to", someMailAddress);
            testData.SetVariable("subject", someSubject);
            testData.SetVariable("body", someBody);
        }

        [Test, Order(6)]
        public void VerifyCreatedMessageExistsInDrafts()
        {
            _mainPage.GoToDrafts();
            object? mail = _mainPage.draftsFolder.GetMailFromTable(testData.GetVariable<string>("subject"));
            Assert.IsNotNull(mail);
        }

        [Test, Order(7)]
        public void SendMailFromDraftAndVerifyMailDissapearedFromDraftFolder()
        {
            _mainPage.messageDialog.CloseAllMailDialogs();
            _mainPage.draftsFolder.GetMailFromTable(testData.GetVariable<string>("subject"))!.Click();
            _mainPage.messageDialog.SendButton.Click();
            Assert.IsNull(_mainPage.draftsFolder.GetMailFromTable(testData.GetVariable<string>("subject")));
        }

        [Test, Order(8)]
        public void GoToSentMailsFolderAndVerifyThatMailIsThere()
        {
            _mainPage.GoToSent();
            Assert.IsNotNull(_mainPage.sentFolder.GetMailFromTable(testData.GetVariable<string>("subject")));
        }

        [Test, Order(9)]
        public void SignOutAndVerifyUserSignedOutSuccessfully()
        {
            _mainPage.accoutDialog.OpenAccountDialog(testData.GetVariable<string>("email"));
            _mainPage.accoutDialog.SwitchToAccountFrame();
            _mainPage.accoutDialog.ClickSignOut();
            webDriver.WaitPageToLoad();
            Assert.IsTrue(_mainPage.logoutPage.isLogoutPageDisplayed());
        }
    }
}