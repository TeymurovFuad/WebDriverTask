using Business.Gmail;
using Core.Browser;
using Core.Business;
using Core.Common.TestConfig;
using Core.Utils.Extensions;
using Core.WebDriver;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Tests.NUnit
{
    public abstract class GmailHooks : CommonHooks
    {
        private BrowserType _browserType { get; set; }
        protected IWebDriver webDriver { get; set; }
        protected bool isChained;
        protected bool _isFailed;
        private string? _url { get; set; }
        public bool StopOnFail { private get; set; }

        protected User user;
        protected Mail mail;
        protected Page page;
        protected TestData testData = new();
        protected DriverManager driverManager = new();
        protected DriverOptions driverOptions;

        protected GmailHooks() : base()
        {
        }

        protected GmailHooks(BrowserType browserType) : base()
        {
            _browserType = browserType;
            driverManager.BuildDriver(browserType, driverOptions);
            webDriver = driverManager.GetWebDriver();
        }

        [OneTimeSetUp]
        public void ClassSetUp()
        {
            testData = new TestData();
            driverManager = new DriverManager();
            if (!string.IsNullOrEmpty(_url))
                driverManager.GetWebDriver().GoToUrl(_url);
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