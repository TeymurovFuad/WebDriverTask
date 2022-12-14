using NUnit.Framework;
using WebDriverTask.Core.Browser;
using GmailTest.Pages.Gmail;
using WebDriverTask.Core.Helpers;
using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using OpenQA.Selenium.Chrome;
using WebDriverTask.Common.TestConfig;
using GmailTest.Business;
using WebDriverTask.Business;

namespace GmailTest.Tests
{
    //[TestFixtureSource(typeof(TestClassDataProvider), "TestCases")]
    //[Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class MailSendTest : Hooks
    {
        protected MainPage mainPage;
        private static string _url = "https://mail.google.com/";


        public MailSendTest() : base(browserType: BrowserType.RemoteFirefox)
        {
            driverOptions = new ChromeOptions();
            StopOnFail= true;
            mainPage = new MainPage(webDriver);
        }

        [OneTimeSetUp]
        public void ClassSetup()
        {

            isChained = true;
            StopOnFail = true;
        }

        [Test, Order(1)]
        public void OpenBrowser()
        {
            webDriver.GoToUrl(_url);
            webDriver.WaitPageToLoad();
            bool pageOpened = webDriver.Title.Contains("gmail", StringComparison.CurrentCultureIgnoreCase);
            Assert.IsTrue(pageOpened);
        }

        [Test, Order(2)]
        [TestCase("english")]
        public void ChangePageLanguageToEnglishAndVerifyItChanged(string expectedLanguage)
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(expectedLanguage);
            string actualLanguage = mainPage.loginPage.GetValueOfCurrentSelectedLanguage();
            Assert.IsTrue(actualLanguage.Contains(expectedLanguage, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test, Order(3)]
        [TestCase("qy54313@gmail.com", "Aa123456____")]
        public void FillUsernameAndPasswordAndLogin(string email, string password)
        {
            mainPage.loginPage.FillEmail(email);
            mainPage.loginPage.ClickNext();
            mainPage.loginPage.FillPassword(password);
            mainPage.loginPage.ClickNext();
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
            mainPage.ToggleMore();
            IWebElement trashFolder = mainPage.TrashFolder;
            webDriver.CreateActions().DragAndDrop(mail, trashFolder).Perform();
            Assert.IsFalse(webDriver.isElementDisplayed(mail));
        }

        [Test, Order(10)]
        public void SignOutAndVerifyUserSignedOutSuccessfully()
        {
            mainPage.LogOut(testData.GetVariable<string>("email"));
            bool loggedOut = webDriver.WaitUntilElementDisplayed(mainPage.logoutPage.ChooseAnAccoutLabel).isDisplayed;
            Assert.IsTrue(loggedOut);
        }
    }
}