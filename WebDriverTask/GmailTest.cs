using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Text.RegularExpressions;

namespace WebDriverTask
{
    [TestFixture]
    public class GmailTest
    {
        private IWebDriver? _driver;
        private const string _createAccountButtonXPath = "//span[@jsname and text()='Create account']";
        private const string _createPersonalUseAccountButtonXPath = "//span[@jsname and text()='For my personal use']";
        private const string _languageChooserDropdownId = "lang-chooser";
        private const string _languageFromDropDownXPath = "//ul[@aria-label='Change language']/li//span[@jsname]/../..";

        [OneTimeSetUp]
        public void InitializeDriver()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");
            _driver = new ChromeDriver();
        }

        [SetUp]
        public void TestSetup()
        {
            _driver!.Manage().Window.Maximize();
        }

        [Test, Order(1)]
        public void AA_OpenBrowser()
        {
            _driver!.Navigate().GoToUrl("https://accounts.google.com/");
            WaitPageLoad();
            Assert.IsTrue(_driver.Title.StartsWith("Sign in"));
        }

        [Test, Order(2)]
        public void AAB_VerifyPageLanguageIsInEnglishOrChangeToEnglishIfLanguageIsOther()
        {
            if (!GetPageLanguage().ToLower().Contains("english"))
            {
                ChangePageLanguage(language: "english");
            }
            var x = GetPageLanguage().ToLower();
            Assert.IsTrue(GetPageLanguage().ToLower().Contains("english"));
        }

        [Test, Order(3)]
        public void BB_VerifyCreateAccountButtonIsVisible()
        {
            Assert.IsTrue(isElementDisplayed(By.XPath(_createAccountButtonXPath)));
        }

        [Test, Order(4)]
        public void CC_ClickCreateAccountButtonAndVerifyThatNewAccountCreationOptionsAreDisplayed()
        {
            ClickElement(By.XPath(_createAccountButtonXPath));
            Assert.True(isElementDisplayed(By.XPath("//ul[@aria-label='Create account']")));
        }

        [Test, Order(4)]
        public void DD_ClickOptionToCreateAccountForPersonalUseAndVerifyThatPageChanged()
        {
            string initialUrl = _driver!.Url.ToString();
            ClickElement(By.XPath(_createPersonalUseAccountButtonXPath+"/../.."));
            WaitPageLoad();
            Assert.That(initialUrl != _driver!.Url.ToString());
        }



        public void ClickElement(By locator, bool? condition=true)
        {
            if (condition.HasValue && (bool)condition)
            {
                _driver!.FindElement(locator).Click();
            }
        }

        public void SendValuesToElement(By element, string value)
        {
            _driver!.FindElement(element).SendKeys(value);
        }

        public void WaitPageLoad(int seconds=5)
        {
            _driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public bool isElementDisplayed(By locator)
        {
            try
            {
                _driver!.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetPageLanguage()
        {
            ICollection<IWebElement> languages;
            string language = string.Empty;
            if (!isElementDisplayed(By.Id(_languageChooserDropdownId)))
            {
                throw new ElementNotVisibleException();
            }
            ClickElement(By.Id(_languageChooserDropdownId), _driver!.FindElement(By.Id(_languageChooserDropdownId)).FindElement(By.XPath("./div/div")).GetAttribute("aria-expanded") == "false");
            languages = _driver!.FindElements(By.XPath(_languageFromDropDownXPath));
            foreach (IWebElement lan in languages)
            {
                if (lan.GetAttribute("aria-selected") == "true")
                {
                    language = lan.Text;
                }
            }
            return language;
        }

        public void ChangePageLanguage(string language)
        {
            ICollection<IWebElement> languages;
            if (!isElementDisplayed(By.Id(_languageChooserDropdownId)))
            {
                throw new ElementNotVisibleException();
            }
            languages = _driver!.FindElements(By.XPath(_languageFromDropDownXPath));
            ClickElement(By.Id(_languageChooserDropdownId), _driver!.FindElement(By.Id(_languageChooserDropdownId)).FindElement(By.XPath("./div/div")).GetAttribute("aria-expanded") == "false");
            foreach (IWebElement lan in languages)
            {
                if (lan.Text.ToLower().Contains(language))
                {
                    lan.Click();
                }
                else
                {
                    throw new NoSuchElementException($"No element found with text {language}");
                }
            }
        }

        [OneTimeTearDown]
        public void DisposeSetup()
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