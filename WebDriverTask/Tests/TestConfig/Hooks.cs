using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using WebDriverTask.Core.Browser;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Tests.TestConfig
{
    public abstract class Hooks
    {
        private string? _url { get; set; }
        private bool _isFailed;

        private BrowserType _browserType { get; set; }
        protected IWebDriver webDriver { get; set; }
        protected TestData testData { get; set; }
        protected DriverManager driverManager { get; set; }
        public bool StopOnFail { private get; set; }

        protected Hooks(BrowserType browserType, string? url=null)
        {
            testData = new TestData();
            driverManager = new DriverManager();
            _browserType = browserType;
            _url = url;
        }

        [OneTimeSetUp]
        public void ClassSetUp()
        {
            driverManager.BuildDriver(_browserType);

            if(!string.IsNullOrEmpty(_url))
                driverManager.GoToUrl(_url);
        }

        [SetUp]
        public void TestSetup()
        {
            if (StopOnFail && _isFailed)
            {
                Assert.Inconclusive("One of the tests is failed. Given that all tests are chained, so failure of one may result in failure of all, thereby flow stopped.");
            }
        }

        [TearDown]
        public void TestTearDown()
        {
            _isFailed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed;
        }

        [OneTimeTearDown]
        public void ClassTearDown()
        {
            driverManager.QuitDriver();
        }
    }
}
