using Business.Gmail;
using Business;
using Core.Browser;
using Core.Business;
using Core.Common.TestConfig;
using Core.WebDriver;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Core.Utils.Extensions;

namespace Tests.SpecflowTests.Gmail
{
    public class GmailBDDHooks: CommonHooks
    {
        protected ScenarioContext scenarioContext;
        private BrowserType? _browserType { get; set; } = null;
        protected IWebDriver webDriver { get; set; }
        protected bool isChained;
        protected bool _isFailed;
        public bool StopOnFail { private get; set; }

        protected User user;
        protected Mail mail;
        protected Page page;
        protected TestData testData = new();
        protected DriverManager driverManager = new();
        protected DriverOptions driverOptions;

        protected GmailBDDHooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driverManager.BuildDriver(_browserType??BrowserType.Firefox, driverOptions);
            webDriver = driverManager.GetWebDriver();
        }

        [OneTimeSetUp]
        public void ClassSetUp()
        {
            testData = new TestData();
            driverManager = new DriverManager();
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
