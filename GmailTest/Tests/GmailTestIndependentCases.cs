using NUnit.Framework;
using WebDriverTask.Core.Browser;
using GmailTest.Pages.Gmail;
using WebDriverTask.Core.Helpers;
using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using System.Drawing;
using OpenQA.Selenium.Chrome;
using WebDriverTask.TestConfig;

namespace GmailTest.Tests
{
    //[TestFixtureSource(typeof(TestClassDataProvider), "TestCases")]
    //[Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class GmailTestIndependentCases : Hooks
    {
        protected MainPage mainPage;
        private static string _url = "https://mail.google.com/";


        public GmailTestIndependentCases() : base(browserType: BrowserType.Chrome, url: _url)
        {
            driverOptions = new ChromeOptions();
            mainPage = new MainPage(webDriver);
            StopOnFail = true;
        }

        [Test]
        [TestCase("qy54313@gmail.com", "Aa123456____")]
        public void Login(string email, string password)
        {
            webDriver.WaitPageToLoad();
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage("english");
            webDriver.WaitUntilElementDisplayed(mainPage.loginPage.CurrentLanguage);
            mainPage.loginPage.FillEmail(email);
            mainPage.loginPage.ClickNext();
            mainPage.loginPage.FillPassword(password);
            mainPage.loginPage.ClickNext();
            Thread.Sleep(3000);
            mainPage.GoToSent();
            mainPage.ToggleMore();
            Thread.Sleep(2000);
            IWebElement source = mainPage.sentFolder.SentMails[0];
            IWebElement target = mainPage.TrashFolder;
            (int st, int sb) = webDriver.JsGetElementOffset(source).topBottom;
            (int sl, int sr) = webDriver.JsGetElementOffset(source).leftRight;
            (int t, int b) = webDriver.JsGetElementOffset(target).topBottom;
            (int l, int r) = webDriver.JsGetElementOffset(target).leftRight;
            webDriver.CreateActions().SourceElement(source);
            webDriver.CreateActions().MoveTo(target: (t, l), source: (st, sl)).Perform();
        }

        [Test, Order(1)]
        public void OpenBrowser()
        {
            webDriver.WaitPageToLoad();
            bool pageDisplayed = webDriver.Title.Contains("gmail", StringComparison.CurrentCultureIgnoreCase);
            Assert.IsTrue(pageDisplayed);
        }

        [Test, Order(2)]
        [TestCase("english")]
        public void ChangePageLanguageToEnglishAndVerifyItChanged(string expectedLanguage)
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(expectedLanguage);
            string actualLanguage = mainPage.loginPage.GetValueOfCurrentSelectedLanguage();
            Assert.That(actualLanguage.Contains(expectedLanguage, StringComparison.CurrentCultureIgnoreCase), Is.True);
        }

        [Test, Order(3)]
        [TestCase("qy54313@gmail.com", "Aa123456____")]
        public void FillUsernameAndPasswordAndLogin(string email, string password)
        {
            mainPage.loginPage.Login(email, password);
            testData.SetVariable("email", email);
            Assert.IsTrue(mainPage.isTitleDisplayed("inbox"));
        }

        [Test, Order(4)]
        public void OpenDialogToComposeNewMail()
        {
            mainPage.ComposeNewMail();
            IWebElement messageDialog = mainPage.messageDialog.GetMailDialog();
            Assert.IsTrue(messageDialog.isElementDisplayed());
        }

        [Test, Order(5)]
        [TestCase("someFakeMail@noSuchAddress.pl", "", "SomeTestBody ")]
        public void FillFieldsInMessageDialogAndCloseDialog(string someMailAddress, string someSubject, string someBody)
        {
            someSubject += StringHelper.GenerateUUID();
            mainPage.messageDialog.MailTo(someMailAddress);
            mainPage.messageDialog.MailSubject(someSubject);
            mainPage.messageDialog.MailBody(someBody);
            mainPage.messageDialog.CloseAllMailDialogs();
            Thread.Sleep(2000);
            Assert.IsTrue(mainPage.messageDialog.AllMailDialogs.Count == 0);

            testData.SetVariable("to", someMailAddress);
            testData.SetVariable("subject", someSubject);
            testData.SetVariable("body", someBody);
        }

        [Test, Order(6)]
        public void VerifyCreatedMessageExistsInDrafts()
        {
            mainPage.GoToDrafts();
            Assert.IsNotNull(mainPage.draftsFolder.GetDraftMailsByValue(testData.GetVariable<string>("subject")));
        }

        [Test, Order(7)]
        public void SendMailFromDraftAndVerifyMailDissapearedFromDraftFolder()
        {
            mainPage.messageDialog.CloseAllMailDialogs();
            mainPage.draftsFolder.GetDraftMailByValue(testData.GetVariable<string>("subject"))!.JsClick(webDriver);
            mainPage.messageDialog.SendButton.Click();
            Assert.IsFalse(mainPage.draftsFolder.GetDraftMailByValue(testData.GetVariable<string>("subject")).isElementDisplayed());
        }

        [Test, Order(8)]
        public void GoToSentMailsFolderAndVerifyThatMailIsThere()
        {
            mainPage.GoToSent();
            mainPage.sentFolder.isSentOpened();
            IWebElement? mail = mainPage.sentFolder.GetSentMailBySubject(testData.GetVariable<string>("subject"));
            Assert.NotNull(mail);
        }

        [Test, Order(9)]
        public void DeleteMailFromSentUsingActionsAndVerifyMailtDeleted()
        {
            string subject = testData.GetVariable<string>("subject");
            IWebElement? mail = mainPage.sentFolder.FindSentMailBySubjectOrBody(subject);
            webDriver.CreateActions().ContextClick(mail).Perform();
            webDriver.CreateActions().Click(mainPage.mailContextMenu.DeleteItem).Perform();
            Assert.IsFalse(webDriver.isElementDisplayed(mail));
        }

        [Test, Order(10)]
        public void SignOutAndVerifyUserSignedOutSuccessfully()
        {
            mainPage.accoutDialog.OpenAccountDialog(testData.GetVariable<string>("email"));
            mainPage.accoutDialog.SwitchToAccountFrame();
            mainPage.accoutDialog.ClickSignOut();
            bool loggedOut = webDriver.WaitUntilElementDisplayed(mainPage.logoutPage.ChooseAnAccoutLabel).isDisplayed;
            Assert.IsTrue(loggedOut);
        }
    }
}