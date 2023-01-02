﻿using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core.Browser;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Tests.TestConfig
{
    public abstract class Hooks
    {
        private BrowserType _browserType { get; set; }
        protected IWebDriver webDriver { get; set; }
        protected TestData testData;
        protected DriverManager driverManager;
        protected ChromeOptions chromeOptions;
        protected FirefoxOptions firefoxOptions;
        protected DriverOptions driverOptions;

        private bool _isFailed;
        private string? _url { get; set; }
        public bool StopOnFail { private get; set; }

        protected Hooks(BrowserType browserType, string? url=null)
        {
            _url = url;
            _browserType = browserType;
            testData = new TestData();
            driverManager = new DriverManager();
        }

        [OneTimeSetUp]
        public void ClassSetUp()
        {
            driverManager.BuildDriver(_browserType, driverOptions);
            webDriver = driverManager.GetWebDriver();
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
