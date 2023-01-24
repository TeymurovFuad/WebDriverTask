
namespace GmailTest.Tests
{
    //[TestFixtureSource(typeof(TestClassDataProvider), "TestCases")]
    //[Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class MailSendTest : Hooks
    {
        protected MainPage mainPage;
        private static string _url = "https://mail.google.com/";


        public MailSendTest() : base(browserType: BrowserType.Chrome)
        {
            isChained = true;
            StopOnFail = true;
            driverOptions = new ChromeOptions();
            mainPage = new MainPage(webDriver);
            user = new(email: "qy54313@gmail.com", password: "Aa123456____");
            mail = new(receiver: "someFakeMail@noSuchAddress.pl", subject: StringHelper.GenerateUUID(), body: "SomeTestBody");
            page = new(title: "Gmail", language: "English", url: "https://mail.google.com/");
        }

        [Test, Order(1)]
        public void OpenBrowser()
        {
            webDriver.GoToUrl(_url);
            webDriver.WaitPageToLoad();
            bool pageOpened = webDriver.Title.Contains(page.Title, StringComparison.CurrentCultureIgnoreCase);
            Assert.IsTrue(pageOpened);
        }

        [Test, Order(2)]
        public void ChangePageLanguageToEnglishAndVerifyItChanged()
        {
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(page.Language);
            string actualLanguage = mainPage.loginPage.GetValueOfCurrentSelectedLanguage();
            Assert.IsTrue(actualLanguage.Contains(page.Language, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test, Order(3)]
        public void FillUsernameAndPasswordAndLogin()
        {
            mainPage.loginPage.Login(email: user.Email, password: user.Password);
            Assert.IsTrue(mainPage.isTitleDisplayed("inbox"));
        }

        [Test, Order(4)]
        public void OpenDialogToComposeNewMail()
        {
            mainPage.ComposeNewMail();
            bool isDisplayed = webDriver.WaitUntilElementDisplayed(mainPage.messageDialog.NewMailDialog).isDisplayed;
            Assert.IsTrue(isDisplayed);
        }

        [Test, Order(5)]
        public void FillFieldsInMessageDialogAndCloseDialog()
        {
            mainPage.messageDialog.FillMailData(receiver: user.Email, subject: mail.Subject, body: mail.Body);
            mainPage.messageDialog.CloseAllMailDialogs();
            Assert.IsFalse(mainPage.messageDialog.GetMailDialog(mail.Subject).isElementDisplayed());
        }

        [Test, Order(6)]
        public void VerifyCreatedMessageExistsInDrafts()
        {
            mainPage.GoToDrafts();
            Assert.IsNotNull(mainPage.draftsFolder.GetDraftMailsByValue(mail.Subject));
        }

        [Test, Order(7)]
        public void SendMailFromDraftAndVerifyMailDissapearedFromDraftFolder()
        {
            mainPage.OpenExistingMail(mail.Subject);
            mainPage.messageDialog.SendButton.Click();
            bool isDisplayed = webDriver.isElementDisplayed(mainPage.messageDialog.MailDialogsByHeaderLocator(mail.Subject));
            Assert.IsFalse(isDisplayed);
        }

        [Test, Order(8)]
        public void GoToSentMailsFolderAndVerifyThatMailIsThere()
        {
            mainPage.GoToSent();
            IWebElement? sentMail = mainPage.sentFolder.GetSentMailBySubject(mail.Subject);
            Assert.NotNull(sentMail);
        }

        [Test, Order(9)]
        public void DeleteMailFromSentAndVerifyDeleted()
        {
            mainPage.ToggleMore();
            webDriver.CreateActions().ContextClick(mainPage.Mail(mail.Subject)).Perform();
            webDriver.CreateActions().Click(mainPage.mailContextMenu.DeleteItem).Perform();
            bool isDisplayed = webDriver.isElementDisplayed(mainPage.sentFolder.MailDialogsByHeaderLocator(mail.Subject));
            Assert.IsFalse(isDisplayed);
        }

        [Test, Order(10)]
        public void SignOutAndVerifyUserSignedOutSuccessfully()
        {
            mainPage.LogOut(user.Email);
            bool loggedOut = webDriver.WaitUntilElementDisplayed(mainPage.logoutPage.ChooseAnAccoutLabel).isDisplayed;
            Assert.IsTrue(loggedOut);
        }
    }
}