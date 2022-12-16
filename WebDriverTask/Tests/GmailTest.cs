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

        //private bool _isFailed;
        //private const string _createAccountButtonXPath = "//span[@jsname and text()='Create account']";
        //private const string _createPersonalUseAccountButtonXPath = "//span[@jsname and text()='For my personal use']";
        //private const string _languageChooserDropdownId = "lang-chooser";
        //private const string _languageFromDropDownXPath = "//div[@id='lang-chooser']/div/div/ul/li//span[@jsname]/../..";
        //private const string _errorForExistingUsernameXPath = "//div[text()='You can use letters, numbers & periods']/../div[@aria-live='assertive' and @aria-atomic='true' ]/div[text()='That username is taken. Try another.']";
        //private const string _nextButtonXPath = "//button//span[text()='Next']/..";
        //private const string _phoneNumberVerificationPageHeaderXPath = "//h1/span[text()='Verifying your phone number']";
        //private const string _emailFieldId = "identifierId";
        //private const string _passwordFieldXPath = "//input[@type='password' and @name='Passwd']";
        //private const string _headingTextOfLoginLogoutPageXPath = "//h1[@id='headingText']/span";
        //private const string _buttonToComposeMail = "//div[text()='Compose']";
        //private const string _newMessageDialogBoxXPath = "//div[@aria-label='New Message']";
        //private const string _toXPath = "//div[@name='to']//input";
        //private const string _subjectXPath = "//input[@name='subjectbox']";
        //private const string _mailBodyXPath = "//div[@aria-label='Message Body']";
        //private const string _newMailDialogBoxSendButtonXPath = "//div[@role='button' and text()='Send']";
        //private const string _closeNewMailComposeModalXPath = "//img[@aria-label='Save & close']";
        //private const string _draftsXPath = "//div[@data-tooltip='Drafts']//a/../..";
        //private const string _messageInDraft_InjecableXPath = "//table/tbody/tr/td//span[contains(text(), '$var')]";
        //private const string _sentXPath = "//div[@data-tooltip='Sent']//a";
        //private const string _messageInSent_InjecableXPath = "//table/tbody/tr/td//div[@title='Inbox']//ancestor-or-self::td//span[contains(text(), '$var')]";
        //private const string _mailHomePageFoldersXPath_Injectable = "//div[@data-tooltip='$folderName']";
        //private const string _dialogBoxContainingSignOutButtonXPath_Injectable = "//a[contains(@aria-label, '($email)') and contains(@href, 'SignOut')]";
        //private const string _iframeContainingDialogBoxForSignOutXPath = "//iframe[@name='account']";
        //private const string _signOutButtonXPath = "//a[contains(@href, 'Logout')]/div[text()='Sign out']";

        [Test, Order(1)]
        public void A_OpenBrowser()
        {
            DriverManager.WaitPageToLoad();
            Assert.IsTrue(driver.Title.Contains("gmail", StringComparison.CurrentCultureIgnoreCase));
        }

        [Test, Order(2)]
        [TestCase("english")]
        public void B_ChangePageLanguageToEnglishAndVerifyItChanged(string expectedLanguage)
        {
            LoginPage.ToggleLanguageChooserDropDown();
            LoginPage.ChangeLanguage(expectedLanguage);
            string actualLanguage = LoginPage.GetValueOfCurrentSelectedLanguage();
            Assert.IsTrue(actualLanguage.Contains(expectedLanguage, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test, Order(3)]
        [TestCase("qy54313@gmail.com", "Aa123456____")]
        public void C_FillUsernameAndPasswordAndLogin(string email, string password)
        {
            LoginPage.FillEmail(email);
            LoginPage.ClickNext();
            LoginPage.FillPassword(password);
            LoginPage.ClickNext();
            testData.SetVariable("email", email);
        }

        [Test, Order(4)]
        public void D_OpenDialogToComposeNewMail()
        {
            MainPage.ComposeNewMail();
            Assert.IsTrue(MessageDialog.isMailDialogDisplayed());
        }

        [Test, Order(5)]
        [TestCase("someFakeMail@noSuchAddress.pl", "", "SomeTestBody ")]
        public void E_FillFieldsInMessageDialogAndCloseDialog(string someMailAddress, string someSubject, string someBody)
        {
            someSubject += StringHelper.GenerateUUID();
            MessageDialog.To(someMailAddress);
            MessageDialog.Subject(someSubject);
            MessageDialog.Body(someBody);
            MessageDialog.Send();
            MessageDialog.CloseAllMailDialogs();
            Assert.IsFalse(MessageDialog.isMailDialogDisplayed());

            testData.SetVariable("to", someMailAddress);
            testData.SetVariable("subject", someSubject);
            testData.SetVariable("body", someBody);
        }

        [Test, Order(6)]
        public void F_VerifyCreatedMessageExistsInDrafts()
        {
            MainPage.GoToDrafts();
            Assert.IsNotNull(Drafts.GetMailFromTable(testData.GetVariable<string>("subject")));
        }

        [Test, Order(7)]
        public void G_SendMailFromDraftAndVerifyMailDissapearedFromDraftFolder()
        {
            MessageDialog.CloseAllMailDialogs();
            Drafts.GetMailFromTable(testData.GetVariable<string>("subject"))!.Click();
            MessageDialogElements.SendButton.Click();
            Assert.IsNull(Drafts.GetMailFromTable(testData.GetVariable<string>("subject")));
        }

        [Test, Order(8)]
        public void H_GoToSentMailsFolderAndVerifyThatMailIsThere()
        {
            MainPage.GoToSent();
            Assert.IsNotNull(Sent.GetMailFromTable(testData.GetVariable<string>("subject")));
        }

        [Test, Order(9)]
        public void I_SignOutAndVerifyUserSignedOutSuccessfully()
        {
            AccoutDialog.OpenAccountDialog(testData.GetVariable<string>("email"));
            AccoutDialog.SwitchToAccountFrame();
            AccoutDialog.ClickSignoutButton();
            DriverManager.WaitPageToLoad();
            Assert.IsTrue(LogotuPage.isLogoutPageDisplayed());
        }

        #region Methods to interact with elements
        //public string GetPageLanguage()
        //{
        //    ICollection<IWebElement> languages;
        //    string language = string.Empty;
        //    if (!_interaction.isElementDisplayed(By.Id(_languageChooserDropdownId)))
        //    {
        //        DriverManager.WaitUntilElementDisplayed(By.Id(_languageChooserDropdownId));
        //    }
        //    _interaction.ClickElement(By.Id(_languageChooserDropdownId), driver!.FindElement(By.Id(_languageChooserDropdownId)).FindElement(By.XPath("./div/div")).GetAttribute("aria-expanded") == "false");
        //    languages = driver!.FindElements(By.XPath(_languageFromDropDownXPath));
        //    foreach (IWebElement lan in languages)
        //    {
        //        if (lan.GetAttribute("aria-selected") == "true")
        //        {
        //            var x = lan.GetAttribute("outerHTML");
        //            language = lan.FindElement(By.XPath("//span/span[@jsname]")).Text;
        //            break;
        //        }
        //    }
        //    _interaction.ClickElement(By.Id(_languageChooserDropdownId), driver!.FindElement(By.Id(_languageChooserDropdownId)).FindElement(By.XPath("./div/div")).GetAttribute("aria-expanded") == "true");
        //    return language;
        //}

        //public void ChangePageLanguage(string language)
        //{
        //    ICollection<IWebElement> languages;
        //    if (!_interaction.isElementDisplayed(By.Id(_languageChooserDropdownId)))
        //    {
        //        DriverManager.WaitUntilElementDisplayed(By.Id(_languageChooserDropdownId));
        //    }
        //    languages = driver!.FindElements(By.XPath(_languageFromDropDownXPath));
        //    _interaction.ClickElement(By.Id(_languageChooserDropdownId), driver!.FindElement(By.Id(_languageChooserDropdownId)).FindElement(By.XPath("./div/div")).GetAttribute("aria-expanded") == "false");
        //    foreach (IWebElement lan in languages)
        //    {
        //        if (lan.Text.ToLower().Contains(language))
        //        {
        //            lan.Click();
        //            _interaction.WaitPageLoad();
        //            break;
        //        }
        //    }
        //    _interaction.ClickElement(By.Id(_languageChooserDropdownId), driver!.FindElement(By.Id(_languageChooserDropdownId)).FindElement(By.XPath("./div/div")).GetAttribute("aria-expanded") == "true");
        //}
        #endregion


        //[TearDown]
        //public void TearDown()
        //{
        //    if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        //    {
        //        _isFailed = true;
        //    }
        //}

        //[OneTimeTearDown]
        //public void ClassClean()
        //{
        //    driver!.Close();
        //    driver.Quit();
        //}
    }
}