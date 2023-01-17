using NUnit.Framework;
using OpenQA.Selenium;
using WebDriverTask.Core.Browser;
using WebDriverTask.Utils.LogerConfiguration;

namespace WebDriverTask.Common.TestConfig
{
    public abstract class CommonHooks
    {
        protected IWebDriver webDriver { get; private set; }
        protected TestLogger testLogger;

        public bool StopOnFail { private get; set; }

        protected CommonHooks()
        {
            testLogger = new TestLogger();
        }
        protected CommonHooks(BrowserType browserType) { }

        [OneTimeSetUp]
        public void ClassSetUp() { }

        [SetUp]
        public void TestSetup()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            testLogger.Log("Test started: "+testName);
        }

        [TearDown]
        public void TestTearDown()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            testLogger.Log("Test finished: " + testName + " - Result: " + TestContext.CurrentContext.Result.Outcome);
        }

        [OneTimeTearDown]
        public void ClassTearDown() { }
    }
}
