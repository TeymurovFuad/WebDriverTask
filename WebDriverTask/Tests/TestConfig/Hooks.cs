using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using WebDriverTask.Core.Browser;
using WebDriverTask.Core.Browser.Configuration;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Tests.TestConfig
{
    public abstract class Hooks
    {
        private BrowserType _browserType;
        private string? _url;
        protected IWebDriver driver;
        protected TestData testData;
        protected DriverManager driverManager;
        protected BrowserSetting browserSetting;
        private bool _isFailed;
        public bool SropOnFail { private get; set; } = true;

        protected Hooks(BrowserType browserType)
        {
            _browserType = browserType;
        }

        protected Hooks(BrowserType browserType, string url)
        {
            _browserType = browserType;
            _url = url;
        }

        [OneTimeSetUp]
        public void ClassSetUp()
        {
            driverManager = new DriverManager();
            driver = driverManager.BuildDriver(_browserType).Instance();
            driverManager.AddArgumentsToDriver();
            if(_url != null && _url != string.Empty)
            {
                Core.WebDriver.Driver.GoToUrl(_url);
            }
            testData = new TestData();
        }

        [SetUp]
        public void TestSetup()
        {
            if (SropOnFail && _isFailed)
            {
                Assert.Inconclusive("One of the tests is failed. Given that all tests are chained, so failure of one may result in failure of all, thereby flow stopped.");
            }
        }

        [TearDown]
        public void TestTearDown()
        {
            if (SropOnFail && TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                _isFailed = true;
            }
        }

        [OneTimeTearDown]
        public void ClassTearDown()
        {
            DriverManager.QuitDriver();
        }
    }
}
