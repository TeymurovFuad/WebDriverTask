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
        private PageInteractions _interaction;
        private bool _isFailed;
        private const string _createAccountButtonXPath = "//span[@jsname and text()='Create account']";
        private const string _createPersonalUseAccountButtonXPath = "//span[@jsname and text()='For my personal use']";
        private const string _languageChooserDropdownId = "lang-chooser";
        private const string _languageFromDropDownXPath = "//div[@id='lang-chooser']/div/div/ul/li//span[@jsname]/../..";
        private const string _errorForExistingUsernameXPath = "//div[text()='You can use letters, numbers & periods']/../div[@aria-live='assertive' and @aria-atomic='true' ]/div[text()='That username is taken. Try another.']";
        private const string _nextButtonXPath = "//button//span[text()='Next']";
        private const string _phoneNumberVerificationPageHeaderXPath = "//h1/span[text()='Verifying your phone number']";

        [OneTimeSetUp]
        public void InitializeTestClass()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");
            _driver = new ChromeDriver();
            _driver!.Manage().Window.Maximize();
            _interaction = new PageInteractions();
        }

        [SetUp]
        public void TestSetup()
        {
            //Thread.Sleep(2000);
            if (_isFailed)
            {
                Assert.Inconclusive("Previos test failed. Given that all tests are chained, so failure of one may result in failure of all, thereby flow stopped.");
            }
        }

        [Test, Order(1)]
        public void AA_OpenBrowser()
        {
            _driver!.Navigate().GoToUrl("https://accounts.google.com/");
            _interaction.WaitPageLoad();
            Assert.IsTrue(_driver.Title.StartsWith("Sign in"));
        }

        [Test, Order(2)]
        public void AAB_VerifyPageLanguageIsInEnglishOrChangeToEnglishIfLanguageIsOther()
        {
            if (!GetPageLanguage().ToLower().Contains("english"))
            {
                ChangePageLanguage(language: "english");
            }
            Regex pattern = new Regex("english.+", RegexOptions.IgnoreCase);
            Assert.That(GetPageLanguage().ToLower(), Does.Match(pattern));
        }

        [Test, Order(3)]
        public void BB_VerifyCreateAccountButtonIsVisible()
        {
            Assert.IsTrue(_interaction.isElementDisplayed(By.XPath(_createAccountButtonXPath)));
        }

        [Test, Order(4)]
        public void CC_ClickCreateAccountButtonAndVerifyThatNewAccountCreationOptionsAreDisplayed()
        {
            _interaction.ClickElement(By.XPath(_createAccountButtonXPath));
            Assert.True(_interaction.isElementDisplayed(By.XPath("//ul[@aria-label='Create account']")));
        }

        [Test, Order(5)]
        public void DD_ClickOptionToCreateAccountForPersonalUseAndVerifyThatPageChanged()
        {
            string initialUrl = _driver!.Url.ToString();
            _interaction.ClickElement(By.XPath(_createPersonalUseAccountButtonXPath+"/.."));
            _interaction.WaitPageLoad();
            Assert.That(initialUrl != _driver!.Url.ToString());
            Assert.That(_driver!.FindElement(By.Id("headingText")).Text, Is.EqualTo("Create your Google Account"));
        }

        [Test, Order(6)]
        [TestCase("atmuserName999", "atmsurname888", "Aa1234567__")]
        public void EE_FillUserDetailsForRegistration(string name, string surname, string password)
        {
            _interaction.SendValuesToElement(By.Id("firstName"), name);
            _interaction.SendValuesToElement(By.Id("lastName"), surname);
            _interaction.SendValuesToElement(By.Id("username"), $"{name}.{surname}");
            Assert.That(_interaction.isElementDisplayed(By.XPath(_errorForExistingUsernameXPath)), Is.False);
            _interaction.SendValuesToElement(By.Name("Password"), password);
            _interaction.SendValuesToElement(By.Name("ConfirmPasswd"), password);
            _interaction.ClickElement(By.XPath(_nextButtonXPath));
            Assert.IsTrue(_interaction.isElementDisplayed(By.XPath(_phoneNumberVerificationPageHeaderXPath)));
        }


        #region Methods to interact with elements
        public string GetPageLanguage()
        {
            ICollection<IWebElement> languages;
            string language = string.Empty;
            if (!_interaction.isElementDisplayed(By.Id(_languageChooserDropdownId)))
            {
                throw new ElementNotVisibleException();
            }
            _interaction.ClickElement(By.Id(_languageChooserDropdownId), _driver!.FindElement(By.Id(_languageChooserDropdownId)).FindElement(By.XPath("./div/div")).GetAttribute("aria-expanded") == "false");
            languages = _driver!.FindElements(By.XPath(_languageFromDropDownXPath));
            foreach (IWebElement lan in languages)
            {
                if (lan.GetAttribute("aria-selected") == "true")
                {
                    language = lan.Text;
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
                throw new ElementNotVisibleException();
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



/*namespace UIAutomation2.Base
{
    public class DriverManager
    {
        private static IWebDriver? driver;

        public static IWebDriver Instance()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void QuitDriver()
        {
            driver!.Quit();
            driver = null;
        }
        public static void CloseDriver()
        {
            if (driver != null)
                driver!.Close();
        }

        public static void ClearAllCookies()
        {
            if (driver != null)
                driver!.Manage().Cookies.DeleteAllCookies();
        }

        public static void WaitPageToLoad(int secondsToWait = 5)
        {
            if (secondsToWait > 0 && driver != null)
                driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secondsToWait);
        }
    }
}
*/