using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Text.RegularExpressions;
using NUnit.Framework.Interfaces;

namespace WebDriverTask
{
    [TestFixture]
    public class GmailTest
    {
        private IWebDriver? _driver;
        private Dictionary<string, dynamic> _variables;
        private PageInteractions? _interaction;
        private bool _isFailed;
        private const string _createAccountButtonXPath = "//span[@jsname and text()='Create account']";
        private const string _createPersonalUseAccountButtonXPath = "//span[@jsname and text()='For my personal use']";
        private const string _languageChooserDropdownId = "lang-chooser";
        private const string _languageFromDropDownXPath = "//div[@id='lang-chooser']/div/div/ul/li//span[@jsname]/../..";
        private const string _errorForExistingUsernameXPath = "//div[text()='You can use letters, numbers & periods']/../div[@aria-live='assertive' and @aria-atomic='true' ]/div[text()='That username is taken. Try another.']";
        private const string _nextButtonXPath = "//button//span[text()='Next']/..";
        private const string _phoneNumberVerificationPageHeaderXPath = "//h1/span[text()='Verifying your phone number']";
        private const string _emailFieldId = "identifierId";
        private const string _passwordFieldXPath = "//input[@type='password' and @name='Passwd']";
        private const string _greetingTextOnPasswordEnteringPageXPath = "//h1[@id='headingText']";
        private const string _buttonToComposeMail = "//div[text()='Compose']";
        private const string _newMessageDialogBoxXPath = "//div[@aria-label='New Message']";
        private const string _toXPath = "//div[@name='to']//input";
        private const string _subjectXPath = "//input[@name='subjectbox']";
        private const string _mailBodyXPath = "//div[@aria-label='Message Body']";
        private const string _newMailDialogBoxSendButtonXPath = "//div[@role='button' and text()='Send']";
        private const string _closeNewMailComposeModalXPath = "//img[@aria-label='Save & close']";
        private const string _draftsXPath = "//div[@data-tooltip='Drafts']//a/../..";
        private const string _messageInDraft_InjecableXPath = "//table/tbody/tr/td//span[contains(text(), '$var')]";
        private const string _sentXPath = "//div[@data-tooltip='Sent']//a";
        private const string _messageInSent_InjecableXPath = "//table/tbody/tr/td//div[@title='Inbox']//ancestor-or-self::td//span[contains(text(), '$var')]";
        private const string _mailHomePageFoldersXPath_Injectable = "//div[@data-tooltip='$folderName']";

        [OneTimeSetUp]
        public void InitializeTestClass()
        {
            _variables = new Dictionary<string, object>();
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");
            _driver = DriverManager.Instance();
            _interaction = new PageInteractions();
        }

        [SetUp]
        public void TestSetup()
        {
            if (_isFailed)
            {
                Assert.Inconclusive("One of the tests is failed. Given that all tests are chained, so failure of one may result in failure of all, thereby flow stopped.");
            }
            long epochTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            SetVariable("epochTime", epochTime);
        }

        [Test, Order(1)]
        public void AA_OpenBrowser()
        {
            _driver!.Navigate().GoToUrl("https://mail.google.com/");
            _interaction.WaitPageLoad();
            Assert.That(_driver.Title, Does.Match("Gmail"));
        }

        [Test, Order(2)]
        public void BB_VerifyPageLanguageIsInEnglishOrChangeToEnglishIfLanguageIsOther()
        {
            if (!GetPageLanguage().ToLower().Contains("english"))
            {
                ChangePageLanguage(language: "english");
            }
            Regex pattern = new Regex("^english");
            Assert.That(GetPageLanguage().ToLower(), Does.Match(pattern));
        }

        [Test, Order(3)]
        [TestCase("qy54313@gmail.com", "Aa123456____", "qwerty")]
        public void CC_FillUsernameAndPasswordAndClickLogin(string mail, string password, string firstName)
        {
            _interaction.SendValuesToElement(By.Id(_emailFieldId), mail);
            _interaction.ClickElement(By.XPath(_nextButtonXPath));
            //Assert.That(_driver!.FindElement(By.XPath(_greetingTextOnPasswordEnteringPageXPath)).Text, Is.EqualTo($"Welcome"));
            _interaction.SendValuesToElement(By.XPath(_passwordFieldXPath), password);
            DriverManager.WaitPageToLoad(10);
            _interaction.ClickElement(By.XPath(_nextButtonXPath));
            //DriverManager.WaitPageToLoad();
        }

        [Test, Order(4)]
        public void DD_OpenDialogToComposeNewMail()
        {
            DriverManager.WaintUntilElementDisplayed(By.XPath(_mailHomePageFoldersXPath_Injectable.Replace("$folderName", "Inbox")));
            _interaction.ClickElement(By.XPath(_buttonToComposeMail));
            Assert.IsTrue(_interaction.isElementDisplayed(By.XPath(_newMessageDialogBoxXPath)));
        }

        [Test, Order(5)]
        [TestCase("someFakeMail@noSuchAddress.pl", "someTestTitle", $"SomeTestBody")]
        public void EE_FillFields_To_Subject_BodyAndCloseDialogBox(string randomMailAddress, string randomSubject, string randomBody)
        {
            randomBody +=  GetVariable<long>("epochTime").ToString();
            _interaction.SendValuesToElement(By.XPath(_toXPath), randomMailAddress);
            _interaction.SendValuesToElement(By.XPath(_subjectXPath), randomSubject);
            _interaction.SendValuesToElement(By.XPath(_mailBodyXPath), randomBody);
            _interaction.ClickElement(By.XPath(_closeNewMailComposeModalXPath));
            Assert.That(_interaction.isElementDisplayed(By.XPath(_closeNewMailComposeModalXPath)), Is.False);

            SetVariable("to", randomMailAddress);
            SetVariable("subject", randomSubject);
            SetVariable("body", randomBody);
        }

        [Test, Order(6)]
        public void FF_VerifyCreatedMessageExistsInDrafts()
        {
            _interaction.ClickElement(By.XPath(_draftsXPath));
            DriverManager.WaitPageToLoad();
            Regex pattern = new Regex("#drafts$");
            Assert.That(_driver.Url, Does.Match(pattern));
            Assert.IsTrue(_interaction.isElementDisplayed(By.XPath(_messageInDraft_InjecableXPath.Replace("$var", GetVariable<string>("subject")))) &&
                _interaction.isElementDisplayed(By.XPath(_messageInDraft_InjecableXPath.Replace("$var", GetVariable<string>("body")))));
        }

        [Test, Order(7)]
        public void GG_SendMailFromDraftAndVerifyMailDissapearedFromDraftFolder()
        {
            _interaction.ClickElement(By.XPath($"{_messageInDraft_InjecableXPath.Replace("$var", GetVariable<string>("body"))}//ancestor-or-self::td"));
            _interaction.ClickElement(By.XPath(_newMailDialogBoxSendButtonXPath));
            Assert.IsFalse(_interaction.isElementDisplayed(By.XPath(_messageInDraft_InjecableXPath.Replace("$var", GetVariable<string>("to")))) || 
                (_interaction.isElementDisplayed(By.XPath(_messageInDraft_InjecableXPath.Replace("$var", GetVariable<string>("subject")))) && 
                _interaction.isElementDisplayed(By.XPath(_messageInDraft_InjecableXPath.Replace("$var", GetVariable<string>("body"))))));
        }

        [Test, Order(8)]
        public void HH_GoToSentMailsFolderAndVerifyThatMailIsThere()
        {
            _interaction.ClickElement(By.XPath(_sentXPath));
            DriverManager.WaitPageToLoad();
            _interaction.isElementDisplayed(By.XPath(_messageInSent_InjecableXPath.Replace("$var", GetVariable<string>("body"))));
        }

        #region Methods to interact with elements
        public string GetPageLanguage()
        {
            ICollection<IWebElement> languages;
            string language = string.Empty;
            if (!_interaction.isElementDisplayed(By.Id(_languageChooserDropdownId)))
            {
                DriverManager.WaintUntilElementDisplayed(By.Id(_languageChooserDropdownId));
            }
            _interaction.ClickElement(By.Id(_languageChooserDropdownId), _driver!.FindElement(By.Id(_languageChooserDropdownId)).FindElement(By.XPath("./div/div")).GetAttribute("aria-expanded") == "false");
            languages = _driver!.FindElements(By.XPath(_languageFromDropDownXPath));
            foreach (IWebElement lan in languages)
            {
                if (lan.GetAttribute("aria-selected") == "true")
                {
                    var x = lan.GetAttribute("outerHTML");
                    language = lan.FindElement(By.XPath("//span/span[@jsname]")).Text;
                    break;
                }
            }
            _interaction.ClickElement(By.Id(_languageChooserDropdownId), _driver!.FindElement(By.Id(_languageChooserDropdownId)).FindElement(By.XPath("./div/div")).GetAttribute("aria-expanded") == "true");
            return language;
        }

        public void ChangePageLanguage(string language)
        {
            ICollection<IWebElement> languages;
            if (!_interaction.isElementDisplayed(By.Id(_languageChooserDropdownId)))
            {
                DriverManager.WaintUntilElementDisplayed(By.Id(_languageChooserDropdownId));
            }
            languages = _driver!.FindElements(By.XPath(_languageFromDropDownXPath));
            _interaction.ClickElement(By.Id(_languageChooserDropdownId), _driver!.FindElement(By.Id(_languageChooserDropdownId)).FindElement(By.XPath("./div/div")).GetAttribute("aria-expanded") == "false");
            foreach (IWebElement lan in languages)
            {
                if (lan.Text.ToLower().Contains(language))
                {
                    lan.Click();
                    _interaction.WaitPageLoad();
                    break;
                }
            }
            _interaction.ClickElement(By.Id(_languageChooserDropdownId), _driver!.FindElement(By.Id(_languageChooserDropdownId)).FindElement(By.XPath("./div/div")).GetAttribute("aria-expanded") == "true");
        }
        #endregion

        public void SetVariable<T>(string key, T value)
        {
            if (!_variables.ContainsKey(key))
            {
                _variables.Add(key, value!);
            }
            _variables[key] = value!;
        }

        public T GetVariable<T>(string key)
        {
            if( _variables.ContainsKey(key))
                return _variables[key];
            else
                throw new KeyNotFoundException(key);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                _isFailed = true;
            }
        }

        [OneTimeTearDown]
        public void ClassClean()
        {
            _driver!.Close();
                _driver.Quit();
        }
    }
}