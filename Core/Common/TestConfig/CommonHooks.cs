﻿using NUnit.Framework;
using OpenQA.Selenium;
using Core.Browser;
using Core.Utils.LogConfig;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Core.Common.TestConfig
{
    public abstract class CommonHooks
    {
        protected IWebDriver webDriver { get; private set; }
        public bool StopOnFail { private get; set; }
        protected IConfiguration secrets { get; private set; }
        protected ILogger log { get { return MessageLogger.GetLogger(); } }

        private readonly Startup _startup = new Startup();

        protected CommonHooks() { }
        protected CommonHooks(BrowserType browserType) { }

        [OneTimeSetUp]
        public void ClassSetUp()
        {
            secrets = _startup.Configuration;
        }

        [SetUp]
        public void TestSetup()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            log.Information("Test started: "+testName);
        }

        [TearDown]
        public void TestTearDown()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            switch (testStatus)
            {
                case TestStatus.Passed:
                case TestStatus.Skipped:
                    log.Information("Test finished: " + testName + " - Result: " + TestContext.CurrentContext.Result.Outcome);
                    break;
                case TestStatus.Failed:
                    log.Error("Test finished: " + testName + " - Result: " + TestContext.CurrentContext.Result.Outcome);
                    break;
                case TestStatus.Warning:
                    log.Warning("Test finished: " + testName + " - Result: " + TestContext.CurrentContext.Result.Outcome);
                    break;
                default:
                    log.Debug("Test finished: " + testName + " - Result: " + TestContext.CurrentContext.Result.Outcome);
                    break;
            }
        }

        [OneTimeTearDown]
        public void ClassTearDown() { }
    }
}
