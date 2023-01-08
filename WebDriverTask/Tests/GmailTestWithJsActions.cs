using NUnit.Framework;
using WebDriverTask.Tests.TestConfig;
using WebDriverTask.Core.Browser;
using WebDriverTask.Pages.Gmail;
using WebDriverTask.Core.Helpers;
using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using System.Drawing;

namespace WebDriverTask.Tests
{
    [TestFixture]
    public class GmailTestWithJsActions : Hooks
    {
        private MainPage _mainPage;
        private static string _url = "https://mail.google.com/";

        public GmailTestWithJsActions() : base(browserType: BrowserType.Chrome, url: _url)
        {
            _mainPage = new MainPage(webDriver);
            StopOnFail = true;
        }

        [Test]
        [TestCase("qy54313@gmail.com", "Aa123456____")]
        public void Login(string email, string password)
        {
            webDriver.WaitPageToLoad();
            _mainPage.loginPage.ToggleLanguageChooserDropDown();
            _mainPage.loginPage.ChangeLanguage("english");
            webDriver.WaitUntilElementDisplayed(_mainPage.loginPage.CurrentLanguage);
            _mainPage.loginPage.FillEmail(email);
            _mainPage.loginPage.ClickNext();
            _mainPage.loginPage.FillPassword(password);
            _mainPage.loginPage.ClickNext();
            Thread.Sleep(3000);
            _mainPage.GoToSent();
            _mainPage.ToggleMore();
            IWebElement source = _mainPage.sentFolder.FindSentMailBySubjectOrBody("5f356c68-4cfb-4aff-bbe7-99a58c2a7cde");
            IWebElement target = _mainPage.TrashFolder;
            Point position = source.Location;
            position = ((ILocatable)target).LocationOnScreenOnceScrolledIntoView;
            webDriver.CreateActions().ContextClick(source).Perform();
            webDriver.CreateActions().Click(webDriver.GetElement(By.XPath("//div[@role='menuitem']//div[text()='Delete']"))).Perform();
            //(int x, int y) = webDriver.GetElementOffset(source).position;
            //webDriver.CreateActions().SourceElement(source).ClickAndHoldElement().MoveToCoordinates(x, y).ReleaseElement().Perform();
        }

        [Test, Order(1)]
        [Ignore("")]
        public void OpenBrowser()
        {
            webDriver.WaitPageToLoad();
            webDriver.WaitPageToLoad();
            Assert.IsTrue(webDriver.Title.Contains("gmail", StringComparison.CurrentCultureIgnoreCase));
        }

        [Test, Order(2)]
        [TestCase("english")]
        [Ignore("")]
        public void ChangePageLanguageToEnglishAndVerifyItChanged(string expectedLanguage)
        {
            _mainPage.loginPage.ToggleLanguageChooserDropDown();
            _mainPage.loginPage.ChangeLanguage(expectedLanguage);
            webDriver.WaitUntilElementDisplayed(_mainPage.loginPage.CurrentLanguage);
            string actualLanguage = _mainPage.loginPage.GetValueOfCurrentSelectedLanguage();
            Assert.That(actualLanguage.Contains(expectedLanguage, StringComparison.CurrentCultureIgnoreCase), Is.True);
        }

        [Test, Order(3)]
        [TestCase("qy54313@gmail.com", "Aa123456____")]
        [Ignore("")]
        public void FillUsernameAndPasswordAndLogin(string email, string password)
        {
            _mainPage.loginPage.FillEmail(email);
            _mainPage.loginPage.ClickNext();
            _mainPage.loginPage.FillPassword(password);
            _mainPage.loginPage.ClickNext();
            testData.SetVariable("email", email);
        }

        [Test, Order(4)]
        [Ignore("")]
        public void OpenDialogToComposeNewMail()
        {
            _mainPage.ComposeNewMail();
            IWebElement messageDialog = _mainPage.messageDialog.GetMailDialog();
            Assert.IsTrue(messageDialog.isElementDisplayed());
        }

        [Test, Order(5)]
        [TestCase("someFakeMail@noSuchAddress.pl", "", "SomeTestBody ")]
        [Ignore("")]
        public void FillFieldsInMessageDialogAndCloseDialog(string someMailAddress, string someSubject, string someBody)
        {
            someSubject += StringHelper.GenerateUUID();
            _mainPage.messageDialog.MailTo(someMailAddress);
            _mainPage.messageDialog.MailSubject(someSubject);
            _mainPage.messageDialog.MailBody(someBody);
            _mainPage.messageDialog.CloseAllMailDialogs();
            Assert.IsTrue(_mainPage.messageDialog.AllMailDialogs.Count == 0);

            testData.SetVariable("to", someMailAddress);
            testData.SetVariable("subject", someSubject);
            testData.SetVariable("body", someBody);
        }

        [Test, Order(6)]
        [Ignore("")]
        public void VerifyCreatedMessageExistsInDrafts()
        {
            _mainPage.GoToDrafts();
            object? mail = _mainPage.draftsFolder.GetDraftMailsByValue(testData.GetVariable<string>("subject"));
            Assert.IsNotNull(mail);
        }

        [Test, Order(7)]
        [Ignore("")]
        public void SendMailFromDraftAndVerifyMailDissapearedFromDraftFolder()
        {
            _mainPage.messageDialog.CloseAllMailDialogs();
            _mainPage.draftsFolder.GetDraftMailByValue(testData.GetVariable<string>("subject"))!.JsClick(webDriver);
            _mainPage.messageDialog.SendButton.Click();
            Assert.IsNull(_mainPage.draftsFolder.GetDraftMailsByValue(testData.GetVariable<string>("subject")));
        }

        [Test, Order(8)]
        [Ignore("")]
        public void GoToSentMailsFolderAndVerifyThatMailIsThere()
        {
            _mainPage.GoToSent();
            Assert.IsNotNull(_mainPage.sentFolder.GetSentMailBySubject(testData.GetVariable<string>("subject")));
        }

        [Test, Order(9)]
        [Ignore("")]
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