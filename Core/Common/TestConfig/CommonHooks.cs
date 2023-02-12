using NUnit.Framework;
using OpenQA.Selenium;
using Core.Browser;
using Core.Utils.LogerConfiguration;
using Microsoft.Extensions.Configuration;

namespace Core.Common.TestConfig
{
    public abstract class CommonHooks
    {
        protected IWebDriver webDriver { get; private set; }
        public bool StopOnFail { private get; set; }
        protected IConfiguration secrets { get; private set; }

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
            TestLogger.Instance.LogMessage("Test started: "+testName);
        }

        [TearDown]
        public void TestTearDown()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            TestLogger.Instance.LogMessage("Test finished: " + testName + " - Result: " + TestContext.CurrentContext.Result.Outcome);
        }

        [OneTimeTearDown]
        public void ClassTearDown() { }
    }
}
