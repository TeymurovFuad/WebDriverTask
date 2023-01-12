using NUnit.Framework;
using OpenQA.Selenium;
using WebDriverTask.Core.Browser;

namespace WebDriverTask.Common.TestConfig
{
    public abstract class CommonHooks
    {
        protected IWebDriver webDriver { get; private set; }

        public bool StopOnFail { private get; set; }

        protected CommonHooks() { }
        protected CommonHooks(BrowserType browserType) { }

        [OneTimeSetUp]
        public void ClassSetUp() { }

        [SetUp]
        public void TestSetup() { }

        [TearDown]
        public void TestTearDown() { }

        [OneTimeTearDown]
        public void ClassTearDown() { }
    }
}
