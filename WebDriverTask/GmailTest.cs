using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace WebDriverTask
{
    [TestFixture]
    public class GmailTest
    {
        private IWebDriver? _driver;
        private const string _createAccountButtonXPath = "//span[@jsname and text()='Create account']";
        private const string _createPersonalUseAccountButtonXPath = "//span[@jsname and text()='For my personal use']";

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

        [Test]
        public void OpenBrowser()
        {
            _driver!.Navigate().GoToUrl("https://accounts.google.com/");
            Assert.IsTrue(_driver.Title.ToLower().Contains("Google"));
        }

        [Test]
        public void VerifyCreateAccountButtonIsVisible()
        {
            Assert.IsTrue(isElementDisplayed(By.XPath(_createAccountButtonXPath)));
        }

        [Test]
        public void ClickCreateAccountButtonAndVerifyThatNewAccountCreationOptionsAreDisplayed()
        {
            ClickElement(By.XPath(_createAccountButtonXPath));
            Assert.True(isElementDisplayed(By.XPath("//ul[@aria-label='Create account']")));
        }

        [Test]
        public void ClickOptionToCreateAccountForPersonalUseAndVerifyThatPageChanged()
        {
            string initialUrl = _driver!.Url.ToString();
            ClickElement(By.XPath(_createPersonalUseAccountButtonXPath));
            WaitPageLoad();
            Assert.That(initialUrl != _driver!.Url.ToString());
        }



        public void ClickElement(By locator)
        {
            _driver!.FindElement(locator).Click();
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
            return _driver!.FindElement(locator).Displayed;
        }

        [TearDown]
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