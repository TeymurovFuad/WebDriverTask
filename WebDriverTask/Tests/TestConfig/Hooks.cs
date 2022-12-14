using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Core.BrowserConfigs;
using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Tests.TestConfig
{
    public abstract class Hooks
    {
        private BrowserType _browserType;
        private string? _url;
        protected IWebDriver _driver;
        protected TestData testData;
        protected DriverManager _driverManager;
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
            DriverManager.Instance(_browserType);
            _driver = Driver.GetDriver();
            _driverManager = new DriverManager();
            _driverManager.AddArgumentsToDriver();
            if(_url != null && _url != string.Empty)
            {
                Driver.GoToUrl(_url);
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
            DriverManager.CloseDriver();
            DriverManager.QuitDriver();
        }
    }
}
