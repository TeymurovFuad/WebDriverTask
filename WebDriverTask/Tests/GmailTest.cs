using NUnit.Framework;
using WebDriverTask.Tests.TestConfig;
using WebDriverTask.Core.Browser;
using WebDriverTask.Pages.Gmail;
using WebDriverTask.Core.WebDriver;
using WebDriverTask.Pages.Gmail.Login;
using WebDriverTask.Pages.Gmail.MailDialog;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Pages.Gmail.Folders;
using WebDriverTask.Pages.Gmail.Logout.AccountDialog;
using WebDriverTask.Pages.Gmail.Logout;

namespace WebDriverTask.Tests
{
    [TestFixture]
    public class GmailTest: Hooks
    {
        private MainPage _mainPage;
        private static string _url = "https://mail.google.com/";

        public GmailTest() : base(browserType: BrowserType.Chrome, url: _url)
        {
            _mainPage = new MainPage();
        }

        [Test, Order(1)]
        public void OpenBrowser()
        {
            DriverManager.WaitPageToLoad();
            Assert.IsTrue(webDriver.Title.Contains("gmail", StringComparison.CurrentCultureIgnoreCase));
        }

        [Test, Order(2)]
        [TestCase("english")]
        public void ChangePageLanguageToEnglishAndVerifyItChanged(string expectedLanguage)
        {
            LoginPage.ToggleLanguageChooserDropDown();
            LoginPage.ChangeLanguage(expectedLanguage);
            string actualLanguage = LoginPage.GetValueOfCurrentSelectedLanguage();
            Assert.That(actualLanguage.Contains(expectedLanguage, StringComparison.CurrentCultureIgnoreCase), Is.True);
        }

        [Test, Order(3)]
        [TestCase("qy54313@gmail.com", "Aa123456____")]
        public void FillUsernameAndPasswordAndLogin(string email, string password)
        {
            LoginPage.FillEmail(email);
            LoginPage.ClickNext();
            LoginPage.FillPassword(password);
            LoginPage.ClickNext();
            testData.SetVariable("email", email);
        }

        [Test, Order(4)]
        public void OpenDialogToComposeNewMail()
        {
            MainPage.ComposeNewMail();
            Assert.IsTrue(MessageDialog.isMailDialogDisplayed());
        }

        [Test, Order(5)]
        [TestCase("someFakeMail@noSuchAddress.pl", "", "SomeTestBody ")]
        public void FillFieldsInMessageDialogAndCloseDialog(string someMailAddress, string someSubject, string someBody)
        {
            someSubject += StringHelper.GenerateUUID();
            MessageDialog.To(someMailAddress);
            MessageDialog.Subject(someSubject);
            MessageDialog.Body(someBody);
            MessageDialog.CloseAllMailDialogs();
            Assert.IsFalse(MessageDialog.isMailDialogDisplayed());

            testData.SetVariable("to", someMailAddress);
            testData.SetVariable("subject", someSubject);
            testData.SetVariable("body", someBody);
        }

        [Test, Order(6)]
        public void VerifyCreatedMessageExistsInDrafts()
        {
            MainPage.GoToDrafts();
            Assert.IsNotNull(DraftsFolder.GetMailFromTable(testData.GetVariable<string>("subject")));
        }

        [Test, Order(7)]
        public void SendMailFromDraftAndVerifyMailDissapearedFromDraftFolder()
        {
            MessageDialog.CloseAllMailDialogs();
            DraftsFolder.GetMailFromTable(testData.GetVariable<string>("subject"))!.Click();
            MessageDialogElements.SendButton.Click();
            Assert.IsNull(DraftsFolder.GetMailFromTable(testData.GetVariable<string>("subject")));
        }

        [Test, Order(8)]
        public void GoToSentMailsFolderAndVerifyThatMailIsThere()
        {
            MainPage.GoToSent();
            Assert.IsNotNull(SentFolder.GetMailFromTable(testData.GetVariable<string>("subject")));
        }

        [Test, Order(9)]
        public void SignOutAndVerifyUserSignedOutSuccessfully()
        {
            AccoutDialog.OpenAccountDialog(testData.GetVariable<string>("email"));
            AccoutDialog.SwitchToAccountFrame();
            AccoutDialog.ClickSignoutButton();
            DriverManager.WaitPageToLoad();
            Assert.IsTrue(LogotuPage.isLogoutPageDisplayed());
        }
    }
}